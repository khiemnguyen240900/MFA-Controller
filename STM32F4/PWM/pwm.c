#include "pwm.h"

void PWM_Config(){
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM1, ENABLE);
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
	GPIO_PinAFConfig(GPIOA, GPIO_PinSource7, GPIO_AF_TIM1);
  GPIO_PinAFConfig(GPIOA, GPIO_PinSource8, GPIO_AF_TIM1);
	
	//Config GPIO for PWM
	//PA7 PA8 TIM1
	GPIO_InitTypeDef GPIO_PWMStruct;
	GPIO_PWMStruct.GPIO_Pin = GPIO_Pin_7 | GPIO_Pin_8;
	GPIO_PWMStruct.GPIO_OType = GPIO_OType_PP;
	GPIO_PWMStruct.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_PWMStruct.GPIO_Mode = GPIO_Mode_AF;
	GPIO_PWMStruct.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOA, &GPIO_PWMStruct);
	
	//Config TIM1 
	TIM_TimeBaseInitTypeDef TIM_BaseStruct;
	TIM_BaseStruct.TIM_Prescaler = 0;
	TIM_BaseStruct.TIM_Period = 8399; //20kHz
	TIM_BaseStruct.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_BaseStruct.TIM_ClockDivision = 0;
	TIM_BaseStruct.TIM_RepetitionCounter = 0;
	TIM_TimeBaseInit(TIM1, &TIM_BaseStruct);
	TIM_Cmd(TIM1, ENABLE);
	
	TIM_OCInitTypeDef TIM_OCStruct;
	TIM_OCStruct.TIM_OCMode = TIM_OCMode_PWM1; //clear on compare match
	TIM_OCStruct.TIM_OutputState = TIM_OutputState_Enable;
	TIM_OCStruct.TIM_OutputNState = TIM_OutputNState_Enable;
	TIM_OCStruct.TIM_OCPolarity = TIM_OCPolarity_High;
	TIM_OCStruct.TIM_OCNPolarity = TIM_OCNPolarity_High;
	TIM_OCStruct.TIM_Pulse = 50*8400/100 - 1;
	
	TIM_OC1Init(TIM1, &TIM_OCStruct);
	TIM_OC1PreloadConfig(TIM1, TIM_OCPreload_Enable);

	TIM_OC2Init(TIM1, &TIM_OCStruct);
	TIM_OC2PreloadConfig(TIM1, TIM_OCPreload_Enable);
	
	TIM_ARRPreloadConfig(TIM1,ENABLE);
	TIM_Cmd(TIM1,ENABLE);
	TIM_CtrlPWMOutputs(TIM1, ENABLE); 
}
void PWM_Out(float duty){
	if (duty > 95.0f) duty = 95.0f;
	else if (duty < 5.0f) duty = 5.0f; 
	TIM1->CCR1 = duty*8400/100-1;
}
