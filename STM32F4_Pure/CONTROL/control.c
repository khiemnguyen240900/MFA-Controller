#include "control.h"

struct Sys InitMotor;
struct Sys *Motor = &InitMotor;
struct MFA_Simple InitController;
struct MFA_Simple *Controller = &InitController;
void ITTimer_Config(){
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
	
	TIM_TimeBaseInitTypeDef		TIM_TimeBaseStructure; 
	TIM_TimeBaseStructure.TIM_ClockDivision 				= TIM_CKD_DIV1;
	TIM_TimeBaseStructure.TIM_Prescaler 						= 8400-1;
	TIM_TimeBaseStructure.TIM_Period 								= (int)(Ts*1000*10)-1;
	TIM_TimeBaseStructure.TIM_CounterMode 					= TIM_CounterMode_Up;
 	TIM_TimeBaseInit(TIM3,&TIM_TimeBaseStructure);
 
	TIM_ITConfig(TIM3,TIM_IT_Update,ENABLE);
//	TIM_Cmd(TIM3,ENABLE);
	
	NVIC_InitTypeDef					NVIC_InitStructure;
	NVIC_InitStructure.NVIC_IRQChannel 										= TIM3_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority	= 3;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority					= 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd 								= ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}
void Noise_Filter(struct Sys *sys){
  sys->y = 0.18127f*sys->y_raw + 0.81873f*sys->y1;
//	if (sys->y > 400.0f) sys->y = 400.0f;
//	if (sys->y < -400.0f) sys->y = -400.0f;
}
void Smooth_Filter(struct Sys *sys){
	sys->yr = 0.18127f*sys->yr_raw + 0.81873f*sys->yr1;
//	if (sys->yr > 400.0f) sys->yr = 400.0f;
//	if (sys->yr < -400.0f) sys->yr = -400.0f;
}
void Update_Value(struct Sys *sys){ 
	sys->yr1 = sys->yr; 
	sys->yr_raw1 = sys->yr_raw;
	sys->y1 = sys->y;
	sys->y_raw1 = sys->y_raw;
}
void InitSys(struct Sys *sys){
	sys->yr = 0.0f;
	sys->yr1 = 0.0f;
	sys->yr_raw = 0.0f;
	sys->yr_raw1 = 0.0f;
	sys->y = 0.0f;
	sys->y1 = 0.0f;
	sys->y_raw = 0.0f;
	sys->y_raw1 = 0.0f;
	sys->e = 0.0f;
}

float Normalize(float input){
	return tanhf(input/20.0f);
}
float Activate(float input){
	return 1 / (1 + expf(-input));
}
void InitCtrl(struct MFA_Simple *ctrl){
	ctrl->N = NEURON_NUM; ctrl->eta = 0.2f; ctrl->Kc = 0.042f; ctrl->alpha = 0.02f;
	ctrl->sum_h = 0.0f; ctrl->eta_Kc_e = 0.0f;
	for (int i = 0; i < ctrl->N; i++)
	{
		ctrl->E[i] = 0.0f;
		ctrl->h[i] = 0.0f;
		ctrl->p[i] = 0.0f; ctrl->q[i] = 0.0f;
		for (int j = 0; j < ctrl->N; j++)
		{
			ctrl->w[i * ctrl->N + j] = 0.0f;
		}
	}
	ctrl->v = 50.0f;
	ctrl->o = 0.0f;
	ctrl->e = 0.0f;
}
void UpdateErrorCtrl(struct MFA_Simple *ctrl,float in_e){
	ctrl->e = in_e;
	for (int i = 0; i < ctrl->N - 1; i++)
	{
		ctrl->E[ctrl->N - i - 1] = ctrl->E[ctrl->N - i - 2];
	}
	ctrl->E[0] = Normalize(in_e);
}
void MFA_Algorithm(struct MFA_Simple *ctrl,float in_e, float yr){
	ctrl->yr = yr;
	UpdateErrorCtrl(ctrl,in_e);
	if (in_e > ctrl->yr*ctrl->alpha || in_e < -ctrl->yr*ctrl->alpha){
		//Cal pj and qj
		for (int j = 0; j < ctrl->N; j++)
		{
			ctrl->p[j] = 0.0f;
			for (int i = 0; i < ctrl->N; i++)
			{
				ctrl->p[j] += ctrl->w[i * ctrl->N + j] * ctrl->E[i];
			}
			ctrl->p[j] += 1;
			ctrl->q[j] = Activate(ctrl->p[j]);
		}
		//Cal ot and vt
		ctrl->o = 0;
		for (int j = 0; j < ctrl->N; j++)
		{
			ctrl->o += ctrl->h[j] * ctrl->q[j];
		}
		ctrl->o += 1;
		ctrl->v = ctrl->Kc * (ctrl->o + ctrl->e) + 50.0f;
		if (ctrl->v > 95.0f) ctrl->v = 95.0f;
		else if (ctrl->v < 5.0f) ctrl->v = 5.0f; 
		//Cal sum_h and eta*Kc*e
		ctrl->sum_h = 0.0f;
		for (int j = 0; j < ctrl->N; j++)
		{
			ctrl->sum_h += ctrl->h[j];
		}
		ctrl->eta_Kc_e = ctrl->eta * ctrl->Kc * ctrl->e;
		//Update wji and hj
		for (int j = 0; j < ctrl->N; j++)
		{
			for (int i = 0; i < ctrl->N; i++)
			{
				ctrl->w[i*ctrl->N+j] += ctrl->eta_Kc_e * ctrl->q[j] * (1 - ctrl->q[j]) * ctrl->E[i] * ctrl->sum_h;
			}
			ctrl->h[j] += ctrl->eta_Kc_e * ctrl->q[j];
		}
	}
}
