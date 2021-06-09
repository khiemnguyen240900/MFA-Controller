/**
  ******************************************************************************
  * @file    
  * @author  Tran Pham
  * @version V1.3.0
  * @date    17-May-2021
  * @brief   Main program body
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
  
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __UART_H
#define __UART_H

/* Includes ------------------------------------------------------------------*/
#include "main.h"

//#define BUFF_SIZE_TX 9;
//#define BUFF_SIZE_RX 17;

extern const int BUFF_SIZE_TX;
extern const int BUFF_SIZE_RX;
extern char RXBuffer[];
extern char TXBuffer[];
/* Exported macro ------------------------------------------------------------*/
/* Exported functions ------------------------------------------------------- */
void UASRT_DMA_Configuration(void);
void sendData(float speed);

#endif /* __UART_H */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
