
void Format_float(float2 UV,out float Out) {
	float2 r = _ScreenParams.xy;						// �X�N���[���𑜓x
	float2 p = UV * r; 									// �X�N���[�����W�����߂�

	Out = length(p * 2.0 - r) / length(r); 		// �O���f�[�V���������߂�
}