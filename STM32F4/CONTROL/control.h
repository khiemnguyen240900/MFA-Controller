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
#ifndef __CONTROL_H
#define __CONTROL_H

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#define NEURON_NUM 8
#define Ts 0.02 //s
struct Sys{
	float yr, yr1, yr_raw, yr_raw1, y, y1, y_raw, y_raw1, e;
};
struct MFA_Simple{
	float yr;													 //set point		
	float eta, Kc, alpha;       			 //learning rate, controller gain, and deadband
	int   N;						   						 //number of neurons
	float e, E[NEURON_NUM];			   		 //error and normalized errors
	float w[NEURON_NUM * NEURON_NUM];  //hidden layer
	float h[NEURON_NUM];    		   		 //output layer
	float p[NEURON_NUM], q[NEURON_NUM];//output of neurons	
	float o, v;						   					 //controller output
	float sum_h, eta_Kc_e;
};
struct PID_Simple{
	float Kp, Ki, Kd;
	float o[2];
	float e[3];
	float T;
	float P, I, D;
};
extern int mode;
extern struct PID_Simple InitPIDController;
extern struct PID_Simple *PIDController;
extern struct MFA_Simple InitController;
extern struct MFA_Simple *Controller;
extern struct Sys *Motor;
extern struct Sys InitMotor;
/* Exported functions ------------------------------------------------------- */
void ITTimer_Config(void);
void MFAController(void);
void InitSys(struct Sys *sys); 
void Update_Value(struct Sys *sys);
void Noise_Filter(struct Sys *sys);
void Smooth_Filter(struct Sys *sys);
float Normalize(float input);
float Activate(float input);
void InitCtrl(struct MFA_Simple *ctrl);
void UpdateErrorCtrl(struct MFA_Simple *ctrl,float in_e);
void MFA_Algorithm(struct MFA_Simple *ctrl,float in_e, float yr);
void InitPIDCtrl(struct PID_Simple *ctrl);
void PID_Update(struct PID_Simple *ctrl, float in_e);
void PID_Control(struct PID_Simple *ctrl, float in_e);
#endif /* __CONTROL_H */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
