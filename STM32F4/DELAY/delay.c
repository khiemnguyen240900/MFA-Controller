#include "delay.h"

void DLTimer_Config(void){
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM6, ENABLE);
	
	TIM_TimeBaseInitTypeDef TIM_DLBaseStruct;
	TIM_DLBaseStruct.TIM_Prescaler = 83;
	TIM_DLBaseStruct.TIM_Period = 999; //delay 1ms
	TIM_DLBaseStruct.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_DLBaseStruct.TIM_ClockDivision = 0;
	TIM_DLBaseStruct.TIM_RepetitionCounter = 0;
	TIM_TimeBaseInit(TIM6, &TIM_DLBaseStruct);
	TIM_UpdateDisableConfig(TIM6, DISABLE);
	TIM_ARRPreloadConfig(TIM6, ENABLE);
	
}

void delay_ms(uint32_t milliSeconds){
	while (milliSeconds--){
		TIM_SetCounter(TIM6, 0);
		TIM_Cmd(TIM6, ENABLE);
		while (TIM_GetFlagStatus(TIM6, TIM_FLAG_Update) != SET);
		TIM_Cmd(TIM6, DISABLE);
		TIM_ClearFlag(TIM6, TIM_FLAG_Update);
	}
}

void delay_us(uint32_t microSeconds){
	TIM_SetCounter(TIM6, 0);
	TIM_Cmd(TIM6, ENABLE);
	while (TIM_GetCounter(TIM6) < microSeconds);
	TIM_Cmd(TIM6, DISABLE);
}
void LEDGPIO_Config(){
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
	
	GPIO_InitTypeDef GPIO_LEDInitStruct;
	GPIO_LEDInitStruct.GPIO_Pin = GPIO_Pin_12;
	GPIO_LEDInitStruct.GPIO_OType = GPIO_OType_PP;
	GPIO_LEDInitStruct.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_LEDInitStruct.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_LEDInitStruct.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOD, &GPIO_LEDInitStruct);	
}
