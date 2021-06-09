/**
  ******************************************************************************
  * @file    Project/STM32F4xx_StdPeriph_Templates/stm32f4xx_it.c 
  * @author  MCD Application Team
  * @version V1.3.0
  * @date    13-November-2013
  * @brief   Main Interrupt Service Routines.
  *          This file provides template for all exceptions handler and 
  *          peripherals interrupt service routine.
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; COPYRIGHT 2013 STMicroelectronics</center></h2>
  *
  * Licensed under MCD-ST Liberty SW License Agreement V2, (the "License");
  * You may not use this file except in compliance with the License.
  * You may obtain a copy of the License at:
  *
  *        http://www.st.com/software_license_agreement_liberty_v2
  *
  * Unless required by applicable law or agreed to in writing, software 
  * distributed under the License is distributed on an "AS IS" BASIS, 
  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  * See the License for the specific language governing permissions and
  * limitations under the License.
  *
  ******************************************************************************
  */

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_it.h"
#include "main.h"


/** @addtogroup Template_Project
  * @{
  */

/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/

extern union ByteToFloat{
	float myfloat;
	char setpoint[4];
	char eta[4];
	char Kc[4];
	char speed[4];
} m_data;

/* Private function prototypes -----------------------------------------------*/
/* Private functions ---------------------------------------------------------*/

/******************************************************************************/
/*            Cortex-M4 Processor Exceptions Handlers                         */
/******************************************************************************/

/**
  * @brief  This function handles NMI exception.
  * @param  None
  * @retval None
  */
void NMI_Handler(void)
{
}

/**
  * @brief  This function handles Hard Fault exception.
  * @param  None
  * @retval None
  */
void HardFault_Handler(void)
{
  /* Go to infinite loop when Hard Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Memory Manage exception.
  * @param  None
  * @retval None
  */
void MemManage_Handler(void)
{
  /* Go to infinite loop when Memory Manage exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Bus Fault exception.
  * @param  None
  * @retval None
  */
void BusFault_Handler(void)
{
  /* Go to infinite loop when Bus Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Usage Fault exception.
  * @param  None
  * @retval None
  */
void UsageFault_Handler(void)
{
  /* Go to infinite loop when Usage Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles SVCall exception.
  * @param  None
  * @retval None
  */
void SVC_Handler(void)
{
}

/**
  * @brief  This function handles Debug Monitor exception.
  * @param  None
  * @retval None
  */
void DebugMon_Handler(void)
{
}

/**
  * @brief  This function handles PendSVC exception.
  * @param  None
  * @retval None
  */
void PendSV_Handler(void)
{
}

/**
  * @brief  This function handles SysTick Handler.
  * @param  None
  * @retval None
  */
void SysTick_Handler(void)
{
}

void DMA1_Stream1_IRQHandler(void){ //nhan gia tri
		char checksum_Rx = 0;
		DMA_ClearITPendingBit(DMA1_Stream1, DMA_IT_TCIF1); //clear IT flag which is 1 when RXBuffer is full
		//GPIO_ToggleBits(GPIOD, GPIO_Pin_12);
		if(RXBuffer[0]=='M' && RXBuffer[1]=='F' && RXBuffer[2]=='A'){
			if (RXBuffer[3]=='S' && RXBuffer[4]=='T' && RXBuffer[5]=='A' && RXBuffer[6]=='R' && RXBuffer[7]=='T'){
					TIM_Cmd(TIM3,ENABLE); //bat TIM3
					//GPIO_SetBits(GPIOD, GPIO_Pin_12);
			}
			else if (RXBuffer[3]=='S' && RXBuffer[4]=='T' && RXBuffer[5]=='O' && RXBuffer[6]=='P'){
					TIM_Cmd(TIM3,DISABLE);
			}
			else if (RXBuffer[3]=='S' && RXBuffer[4]=='S' && RXBuffer[5]=='P' && RXBuffer[6]=='D'){
					GPIO_ToggleBits(GPIOD, GPIO_Pin_12);
					m_data.myfloat = 0.0;
					for (int k = 0; k<11; k++){
						checksum_Rx += RXBuffer[k];
					}
					if (checksum_Rx == RXBuffer[11]){
//						GPIO_SetBits(GPIOD, GPIO_Pin_12);
								for(int k = 0; k < 4; k++){
									m_data.setpoint[k] = RXBuffer[7+k];
								}
								if (m_data.myfloat <= 400) Motor->yr_raw = m_data.myfloat;
					}
			}
			else {
					for (int k = 0; k<11; k++){
						checksum_Rx += RXBuffer[k];
					}
					if (checksum_Rx == RXBuffer[11]){
						for(int k = 0; k < 4; k++){
							m_data.Kc[k] = RXBuffer[3+k];
						}
						Controller->Kc = m_data.myfloat;
						
						for(int k = 0; k < 4; k++){
							m_data.eta[k] = RXBuffer[7+k];
						}
						
						if (m_data.myfloat <= 1) Controller->eta = m_data.myfloat;		
					}
			}
		}
	DMA_Cmd(DMA1_Stream1, ENABLE);
}
void TIM3_IRQHandler(void){
		static int i = 0;
		if (TIM_GetITStatus(TIM3, TIM_FLAG_Update) == SET){
			if (i<2) i++;
			else {
				i = 0;
				sendData();
				
			}
			Smooth_Filter(Motor);
			Motor->y_raw = (float)readEnc()*60.0f/(4.0f*234.0f)/Ts;
			Noise_Filter(Motor);
			Motor->e = Motor->yr - Motor->y;
			MFA_Algorithm(Controller, Motor->e, Motor->yr);
			PWM_Out(Controller->v);
			Update_Value(Motor);			
		}	
		TIM_ClearITPendingBit (TIM3, TIM_FLAG_Update);
}

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
