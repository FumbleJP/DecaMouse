using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecaMouse
{
	public class ShakeDetector
	{
		/// <summary>
		/// 振られていないと判定するまでの回数
		/// </summary>
		/// <remarks>
		/// サンプリング周期
		/// </remarks>
		public int Cooldown
		{
			get => _cooldown;
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException("value");
				if (_cooldown != value)
				{
					_cooldown = value;
					Reset();
				}
			}
		}
		private int _cooldown;

		/// <summary>
		/// 振られていると判定するための移動量閾値
		/// </summary>
		/// <remarks>
		/// 1サンプリング周期中にこの設定数ピクセルを超えて同一方向に移動していると振り操作中と判定
		/// </remarks>
		public int Deadzone { get; set; }

		/// <summary>
		/// 方向転換の閾値
		/// </summary>
		/// <remarks>
		/// Cooldown回のサンプリング周期中にこの設定回数以上方向転換があれば振っていると判定
		/// </remarks>
		public int DirectionChanges { get; set; }

		/// <summary>
		/// マウスボタンが押されているときは無視するかどうか
		/// </summary>
		public bool IgnoreMouseButtonHeld { get; set; }

		/// <summary>
		/// 方向転換のバッファ
		/// </summary>
		private bool[] _directionChanges;
		/// <summary>
		/// 方向転換数
		/// </summary>
		private int _directionChangeCount;
		/// <summary>
		/// 方向転換のバッファのインデックス
		/// </summary>
		private int _directionChangeIndex;

		/// <summary>
		/// 最後の位置
		/// </summary>
		private int _lastPosition;
		/// <summary>
		/// 最後の方向
		/// </summary>
		private int _lastDirection;

		/// <summary>
		/// 方向転換情報の追加
		/// </summary>
		/// <param name="isDirectionChange">方向転換が発生したかどうか</param>
		private void AddDirectionChange(bool isDirectionChange)
		{
			// 今回書き込みする保存先が反転しているならば反転回数を減らす
			if (_directionChanges[_directionChangeIndex])
				_directionChangeCount--;
			// 今回反転してるならば反転回数を増やす
			if (isDirectionChange)
				_directionChangeCount++;
			// 今回の反転情報を保存
			_directionChanges[_directionChangeIndex] = isDirectionChange;
			// 次回の保存先を設定
			_directionChangeIndex = (_directionChangeIndex + 1) % Cooldown;
		}

		/// <summary>
		/// サンプリング追加
		/// </summary>
		/// <param name="currentPosition">今回の位置</param>
		/// <returns>振っていると判定された場合はtrue、それ以外はfalse</returns>
		public bool AddSample(int currentPosition)
		{
			// 未初期化
			if (_directionChanges == null)
				return false;
			// このサンプルで移動した量
			int delta = currentPosition - _lastPosition;

			// 移動量の閾値以下の場合は移動していないとみなす
			if (Math.Abs(delta) <= Deadzone)
				delta = 0;
			// 前回の移動量と符号が異なっている場合は方向転換とみなす
			// _lastDirection == Int32.MinValueの場合は初回サンプリングなので方向転換とみなさない
			var directionChange = _lastDirection != Int32.MinValue && ((delta < 0 && 0 < _lastDirection) || (0 < delta && _lastDirection < 0));
			// マウスボタンが押されているときは方向転換の情報を追加しない
			if (!IgnoreMouseButtonHeld || Control.MouseButtons == MouseButtons.None)
				AddDirectionChange(directionChange);
			if (delta != 0 || _lastDirection == Int32.MinValue)
				_lastDirection = delta;
			_lastPosition = currentPosition;
			// 閾値を超えた方向転換の場合にtrueを返す
			return directionChange && DirectionChanges <= _directionChangeCount;
		}

		/// <summary>
		/// リセット
		/// </summary>
		public void Reset()
		{
			_directionChanges = new bool[Cooldown];
			_directionChangeCount = 0;
			_directionChangeIndex = 0;
			_lastPosition = 0;
			_lastDirection = Int32.MinValue;
		}
	}
}
