#include "enc.h"

u32 preEncValue = 0, encValue = 0;


void enc_Config(){
	
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM5, ENABLE);
	//Config GPIO for 2 channels of ENC
			//PA00		CHANNEL_A
			//PA01		CHANNEL_B
	GPIO_InitTypeDef	GPIO_ENC_InitStructure;
  GPIO_ENC_InitStructure.GPIO_Pin 					= GPIO_Pin_0| GPIO_Pin_1; 
	GPIO_ENC_InitStructure.GPIO_OType 				= GPIO_OType_PP;
	GPIO_ENC_InitStructure.GPIO_Mode 					= GPIO_Mode_AF;
	GPIO_ENC_InitStructure.GPIO_PuPd 					= GPIO_PuPd_NOPULL; 		
	GPIO_ENC_InitStructure.GPIO_Speed 				= GPIO_Speed_25MHz;
	GPIO_Init(GPIOA,&GPIO_ENC_InitStructure);
	
	GPIO_PinAFConfig(GPIOA,GPIO_PinSource0,GPIO_AF_TIM5);
	GPIO_PinAFConfig(GPIOA,GPIO_PinSource1,GPIO_AF_TIM5);
	
	//cau hinh input capture cho 2 kenh A, B
	TIM_TimeBaseInitTypeDef										TIM_TimeBaseStructure;
  TIM_TimeBaseStructure.TIM_Prescaler 			= 0;
  TIM_TimeBaseStructure.TIM_Period 					= 0xFFFFFFFF;	
  TIM_TimeBaseStructure.TIM_ClockDivision 	= TIM_CKD_DIV1;
  TIM_TimeBaseInit(TIM5,&TIM_TimeBaseStructure);
	
	TIM_ICInitTypeDef 		TIM_ICInitStructure;
  TIM_ICInitStructure.TIM_Channel 					= TIM_Channel_1 | TIM_Channel_2;
  TIM_ICInitStructure.TIM_ICFilter 					= 10; 
  TIM_ICInitStructure.TIM_ICPolarity 				= TIM_ICPolarity_Rising;
  TIM_ICInitStructure.TIM_ICPrescaler 			= TIM_ICPSC_DIV4;
  TIM_ICInitStructure.TIM_ICSelection 			= TIM_ICSelection_DirectTI;
  TIM_ICInit(TIM5,&TIM_ICInitStructure);
 
  TIM_EncoderInterfaceConfig(TIM5,TIM_EncoderMode_TI12,TIM_ICPolarity_Rising,TIM_ICPolarity_Rising);
  TIM_SetCounter(TIM5,1000000000);
  TIM_Cmd(TIM5,ENABLE);
  TIM_ClearFlag(TIM5,TIM_FLAG_Update);
}
u32 readEnc(){
	preEncValue = encValue;
	encValue = TIM5->CNT;
	return encValue - preEncValue;
}
