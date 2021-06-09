#include "uart.h"
/* Exported constants --------------------------------------------------------*/
const int BaudRate = 115200;
const int BUFF_SIZE_TX = 9;
const int BUFF_SIZE_RX = 13;
/* Exported variables ------------------------------------------------------------*/
union ByteToFloat{
	float myfloat;
	char setpoint[4];
	char eta[4];
	char Kc[4];
	char speed[4];
} m_data;

char RXBuffer[BUFF_SIZE_RX];
char TXBuffer[BUFF_SIZE_TX];


void UASRT_DMA_Configuration (){
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3, ENABLE);
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_DMA1, ENABLE);
	
	GPIO_PinAFConfig(GPIOD, GPIO_PinSource8, GPIO_AF_USART3);
	GPIO_PinAFConfig(GPIOD, GPIO_PinSource9, GPIO_AF_USART3); 
	
	/* Khoi tao chân TX & RX Uart*/
	//TX: PD8
	//RX:PD9
	GPIO_InitTypeDef GPIO_InitStruct;
	GPIO_InitStruct.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStruct.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStruct.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_9;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOD, &GPIO_InitStruct);
	
	USART_InitTypeDef USART_InitStruct;
	USART_InitStruct.USART_BaudRate = BaudRate;
	USART_InitStruct.USART_WordLength = USART_WordLength_8b;
	USART_InitStruct.USART_StopBits = USART_StopBits_2;
	USART_InitStruct.USART_Parity = USART_Parity_No;
	USART_InitStruct.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStruct.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
	USART_Init(USART3, &USART_InitStruct);

	USART_Cmd(USART3, ENABLE);
	/* Enable USART3 DMA */
	USART_DMACmd(USART3, USART_DMAReq_Tx, ENABLE);
	USART_DMACmd(USART3, USART_DMAReq_Rx, ENABLE);
	
	/* Configure DMA Initialization Structure */
	DMA_InitTypeDef DMA_InitStructure;
	DMA_InitStructure.DMA_FIFOMode = DMA_FIFOMode_Disable ;
	DMA_InitStructure.DMA_FIFOThreshold = DMA_FIFOThreshold_HalfFull ;
	DMA_InitStructure.DMA_MemoryBurst = DMA_MemoryBurst_Single ;
	DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_Byte;
	DMA_InitStructure.DMA_MemoryInc = DMA_MemoryInc_Enable;
	DMA_InitStructure.DMA_Mode = DMA_Mode_Normal;
	DMA_InitStructure.DMA_PeripheralBaseAddr =(uint32_t) (&(USART3->DR)) ;
	DMA_InitStructure.DMA_PeripheralBurst = DMA_PeripheralBurst_Single;
	DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_Byte;
	DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;
	DMA_InitStructure.DMA_Priority = DMA_Priority_High;

	/* Configure TX DMA */
	DMA_InitStructure.DMA_BufferSize = BUFF_SIZE_TX;
	DMA_InitStructure.DMA_Channel = DMA_Channel_4 ;
	DMA_InitStructure.DMA_DIR = DMA_DIR_MemoryToPeripheral ;
	DMA_InitStructure.DMA_Memory0BaseAddr =(uint32_t)TXBuffer ;
	DMA_Init(DMA1_Stream3,&DMA_InitStructure);
	DMA_Cmd(DMA1_Stream3, ENABLE);
	
	/* Configure RX DMA */
	DMA_InitStructure.DMA_BufferSize = BUFF_SIZE_RX;
	DMA_InitStructure.DMA_Channel = DMA_Channel_4 ;
	DMA_InitStructure.DMA_DIR = DMA_DIR_PeripheralToMemory ;
	DMA_InitStructure.DMA_Memory0BaseAddr =(uint32_t)&RXBuffer;
	DMA_Init(DMA1_Stream1,&DMA_InitStructure);	
	DMA_Cmd(DMA1_Stream1, ENABLE);
	
	/* Enable DMA Interrupt to the highest priority */
	NVIC_InitTypeDef NVIC_InitStruct;
	NVIC_InitStruct.NVIC_IRQChannel = DMA1_Stream1_IRQn;
	NVIC_InitStruct.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStruct.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStruct.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStruct);
	/* Transfer complete interrupt mask */
	DMA_ITConfig(DMA1_Stream1, DMA_IT_TC, ENABLE);
}

void sendData(){
	char checksum_Tx = 0;
	m_data.myfloat = Motor->y;
	TXBuffer[0]='M'; TXBuffer[1]='F'; TXBuffer[2]='A';

	for (int i = 0; i < 4; i++){
		TXBuffer[3+i] = m_data.speed[i];
	}
	for (int i = 0; i<7; i++){
		checksum_Tx += TXBuffer[i];
	}
	TXBuffer[7] = checksum_Tx;
	TXBuffer[8] = '$';
	GPIO_ToggleBits(GPIOD, GPIO_Pin_12);
	DMA_ClearFlag(DMA1_Stream3, DMA_FLAG_TCIF3);
  DMA1_Stream3->NDTR = BUFF_SIZE_TX;
  DMA_Cmd(DMA1_Stream3, ENABLE);
}
