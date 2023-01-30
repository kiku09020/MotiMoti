
void Format_float(float2 UV,out float Out) {
	float2 r = _ScreenParams.xy;						// スクリーン解像度
	float2 p = UV * r; 									// スクリーン座標を求める

	Out = length(p * 2.0 - r) / length(r); 		// グラデーションを求める
}