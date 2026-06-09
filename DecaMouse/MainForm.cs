using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DecaMouse
{
	/// <summary>
	/// メインフォーム
	/// </summary>
	public partial class MainForm : Form
	{
		#region Win32API
		/// <summary>
		/// [Win32API]SPIF_SENDCHANGE
		/// </summary>
		private const uint SPIF_SENDCHANGE = 0x02;
		/// <summary>
		/// [Win32API]SPI_GETMOUSECURSORSIZE
		/// </summary>
		private const uint SPI_GETMOUSECURSORSIZE = 0x2028;
		/// <summary>
		/// [Win32API]SPI_SETMOUSECURSORSIZE
		/// </summary>
		private const uint SPI_SETMOUSECURSORSIZE = 0x2029;
		/// <summary>
		/// [Win32API]SystemParametersInfo
		/// </summary>
		/// <param name="uiAction">SPI_*</param>
		/// <param name="uiParam">Param</param>
		/// <param name="pvParam">Param</param>
		/// <param name="fWinIni">SPIF_*</param>
		/// <returns>成否</returns>
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);
		#endregion

		/// <summary>
		/// マウスポインターサイズの最小
		/// </summary>
		private const int MinDecaMouse = 32;

		/// <summary>
		/// マウスポインターサイズの最大
		/// </summary>
		private const int MaxDecaMouse = 256;

		/// <summary>
		/// 設定ファイル名
		/// </summary>
		private const string SettingsFileName = "Settings.xml";

		/// <summary>
		/// 自動起動レジストリ
		/// </summary>
		private const string StartupRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

		/// <summary>
		/// レジストリ登録用のアプリケーション名
		/// </summary>
		private const string ApplicationName = "DecaMouse";

		/// <summary>
		/// タイトル
		/// </summary>
		private string _applicationTitle;

		/// <summary>
		/// プロダクト名
		/// </summary>
		private string _applicationProductName;

		/// <summary>
		/// コピーライト
		/// </summary>
		private string _applicationCopyright;

		/// <summary>
		/// バージョン
		/// </summary>
		private string _applicationVersion;

		/// <summary>
		/// オレオレフォルダパス
		/// </summary>
		private string _pathCompanyFolder;

		/// <summary>
		/// データフォルダパス
		/// </summary>
		private string _pathDataFolder;

		/// <summary>
		/// 設定ファイルパス
		/// </summary>
		private string _pathSettings;

		private ApplicationSettings _settings;

		/// <summary>
		/// ふりふりXカウント
		/// </summary>
		private int _shakeX = 0;

		/// <summary>
		/// ふりふりYカウント
		/// </summary>
		private int _shakeY = 0;

		/// <summary>
		/// 振られてないXカウント
		/// </summary>
		private int _noShakeX = 0;

		/// <summary>
		/// 振られてないYカウント
		/// </summary>
		private int _noShakeY = 0;

		/// <summary>
		/// 最初のマウスポインターサイズ
		/// </summary>
		private int _initialCursorSize = 0;

		/// <summary>
		/// 変更前のマウスポインターサイズ
		/// </summary>
		private int _originalCursorSize = 0;

		/// <summary>
		/// 現在設定中のマウスポインターサイズ
		/// </summary>
		private int _currentCursorSize = 0;

		/// <summary>
		/// API用のバッファ
		/// </summary>
		IntPtr _valueBuffer;

		/// <summary>
		/// ふりふりX
		/// </summary>
		private ShakeDetector _shakeDetectorX = new ShakeDetector();

		/// <summary>
		/// ふりふりY
		/// </summary>
		private ShakeDetector _shakeDetectorY = new ShakeDetector();

		/// <summary>
		/// トレイからの終了
		/// </summary>
		private bool _closing;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			var assembly = Assembly.GetEntryAssembly();
			var fileVerInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			_applicationTitle = _applicationProductName = fileVerInfo.ProductName;
			_lblApplicationCopyright.Text = _applicationCopyright = fileVerInfo.LegalCopyright;
			_lblApplicationVersion.Text = _applicationVersion = fileVerInfo.ProductVersion;
			_pathCompanyFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileVerInfo.CompanyName);
			_pathDataFolder = Path.Combine(_pathCompanyFolder, _applicationTitle);
			_pathSettings = Path.Combine(_pathDataFolder, SettingsFileName);
			_settings = ApplicationSettings.Load(_pathSettings);

			switch (_settings.ActionX)
			{
				default:
					_radNoneX.Checked = true; break;
				case ApplicationSettings.Actions.IncreasePointerSize:
					_radBigMouseX.Checked = true; break;
				case ApplicationSettings.Actions.MoveToCenter:
					_radCenterMouseX.Checked = true; break;
			}
			switch (_settings.ActionY)
			{
				default:
					_radNoneY.Checked = true; break;
				case ApplicationSettings.Actions.IncreasePointerSize:
					_radBigMouseY.Checked = true; break;
				case ApplicationSettings.Actions.MoveToCenter:
					_radCenterMouseY.Checked = true; break;
			}
			_tbCooldownX.Value = _settings.CooldownX;
			_tbDistanceX.Value = _shakeDetectorX.Deadzone = _settings.DeadzoneX;
			_tbDirectionChangeX.Value = _shakeDetectorX.DirectionChanges = _settings.DirectionChangesX;
			_shakeDetectorX.Cooldown = _tbCooldownX.Value + _tbDirectionChangeX.Value;

			_tbCooldownY.Value = _settings.CooldownY;
			_tbDistanceY.Value = _shakeDetectorY.Deadzone = _settings.DeadzoneY;
			_tbDirectionChangeY.Value = _shakeDetectorY.DirectionChanges = _settings.DirectionChangesY;
			_shakeDetectorY.Cooldown = _tbCooldownY.Value + _tbDirectionChangeY.Value;

			_chkIgnoreButtonHeld.Checked = _settings.IgnoreMouseButtonHeld;

			_chkGraduallyEnlarge.Checked = _settings.GraduallyIncreasePointerSize;
			_tbGraduallyEnlarge.Value = _settings.IncreasePointerSize;
			_chkGraduallyShirink.Checked = _settings.GraduallyDecreasePointerSize;
			_tbGraduallyShirink.Value = _settings.DecreasePointerSize;

			_chkAutoExec.Checked = IsRegisteredStartup();

			_valueBuffer = Marshal.AllocHGlobal(sizeof(int));
			_timSampling.Enabled = true;
		}

		/// <summary>
		/// フォームの表示状態を設定します。
		/// </summary>
		/// <param name="value">表示する場合はtrue、非表示にする場合はfalse</param>
		protected override void SetVisibleCore(bool value)
		{
			if (!IsHandleCreated)
			{
				CreateHandle();
				value = false;
			}
			base.SetVisibleCore(value);
		}

		/// <summary>
		/// Loadイベントハンドラー
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			// タブページ上のトラックバーの背景がおかしい問題を修正
			void fix(Control container)
			{
				if (container.Controls != null)
				{
					foreach (var control in container.Controls)
					{
						switch (control)
						{
							case TrackBar trackBar:
								for (var parent = trackBar.Parent; parent != null; parent = parent.Parent)
								{
									if (parent is TabPage parentTabPage)
									{
										if (parentTabPage.UseVisualStyleBackColor)
										{
											trackBar.BackColor = SystemColors.Window;
											break;
										}
									}
								}
								break;
							case Control inner:
								fix(inner);
								break;
						}
					}
				}
			}
			fix(this);
		}

		/// <summary>
		/// フォームが閉じられる際の処理を行います。ユーザーによる閉じる操作の場合、閉じる処理をキャンセルしてフォームを非表示にします。	
		/// </summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベント データを格納している FormClosingEventArgs。</param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !_closing)
			{
				e.Cancel = true;
				Visible = false;
			}
		}

		/// <summary>
		/// 横方向のアクションをフォームの状態から取得して設定に保存します。
		/// </summary>
		private void GetActionsFromFormX()
		{
			if (_radBigMouseX.Checked)
				_settings.ActionX = ApplicationSettings.Actions.IncreasePointerSize;
			else if (_radCenterMouseX.Checked)
				_settings.ActionX = ApplicationSettings.Actions.MoveToCenter;
			else if (_radNoneX.Checked)
				_settings.ActionX = ApplicationSettings.Actions.None;
			// no else
		}

		/// <summary>
		/// 縦方向のアクションをフォームの状態から取得して設定に保存します。
		/// </summary>
		private void GetActionsFromFormY()
		{
			if (_radBigMouseY.Checked)
				_settings.ActionY = ApplicationSettings.Actions.IncreasePointerSize;
			else if (_radCenterMouseY.Checked)
				_settings.ActionY = ApplicationSettings.Actions.MoveToCenter;
			else if (_radNoneY.Checked)
				_settings.ActionY = ApplicationSettings.Actions.None;
			// no else

		}

		/// <summary>
		/// フォームが閉じられた際の処理を行います。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_timSampling.Enabled = false;
			// 終了前にマウスポインターサイズを戻す
			RestoreMouse();
			Marshal.FreeHGlobal(_valueBuffer);
			GetActionsFromFormX();
			GetActionsFromFormY();

			_settings.CooldownX = _tbCooldownX.Value;
			_settings.DeadzoneX = _tbDistanceX.Value;
			_settings.DirectionChangesX = _tbDirectionChangeX.Value;
			_settings.CooldownY = _tbCooldownY.Value;
			_settings.DeadzoneY = _tbDistanceY.Value;
			_settings.DirectionChangesY = _tbDirectionChangeY.Value;

			_settings.IgnoreMouseButtonHeld = _chkIgnoreButtonHeld.Checked;

			_settings.GraduallyIncreasePointerSize = _chkGraduallyEnlarge.Checked;
			_settings.IncreasePointerSize = _tbGraduallyEnlarge.Value;
			_settings.GraduallyDecreasePointerSize = _chkGraduallyShirink.Checked;
			_settings.DecreasePointerSize = _tbGraduallyShirink.Value;

			_settings.Save(_pathSettings);
		}

		/// <summary>
		/// マウスのサイズ変更
		/// </summary>
		/// <param name="increase"></param>
		private void BigMouse(int increase)
		{
			if (!SystemParametersInfo(SPI_GETMOUSECURSORSIZE, 0, _valueBuffer, 0))
				return;
			var currentSize = Marshal.ReadInt32(_valueBuffer);
			// 取ったサイズが不正値なら初期サイズに、初期サイズの取得時に不正なら最小値に設定する
			if (currentSize < MinDecaMouse || MaxDecaMouse < currentSize)
				currentSize = _initialCursorSize != 0 ? _initialCursorSize : MinDecaMouse;
			// 初期サイズを取得していないならば保存しておく
			if (_initialCursorSize == 0)
				_initialCursorSize = currentSize;
			// 変更前サイズを保存しておく
			if (_originalCursorSize == 0)
				_currentCursorSize = _originalCursorSize = currentSize;
			// 自分以外がサイズ変更を行っている場合、そのサイズを初期サイズとする
			if (_currentCursorSize != currentSize)
				_originalCursorSize = currentSize;
			_currentCursorSize = currentSize + increase;
			// 下限
			if (_currentCursorSize < MinDecaMouse)
				_currentCursorSize = MinDecaMouse;
			// 上限
			if (MaxDecaMouse < _currentCursorSize)
				_currentCursorSize = MaxDecaMouse;
			// 既に上限で変える必要はない？
			if (currentSize == _currentCursorSize)
				return;
			_ = SystemParametersInfo(SPI_SETMOUSECURSORSIZE, 0, new IntPtr(_currentCursorSize), SPIF_SENDCHANGE);
		}

		/// <summary>
		/// マウスのサイズ変更
		/// </summary>
		/// <param name="decrease"></param>
		private void RestoreMouse(int decrease)
		{
			if (_originalCursorSize == 0)
				return;
			if (_currentCursorSize <= _originalCursorSize)
			{
				_originalCursorSize = _currentCursorSize = 0;
				return;
			}
			if (!SystemParametersInfo(SPI_GETMOUSECURSORSIZE, 0, _valueBuffer, 0))
				return;
			var currentSize = Marshal.ReadInt32(_valueBuffer);
			// 自分以外がサイズ変更を行っている場合、戻し操作をやめる
			if (_currentCursorSize != currentSize)
			{
				_originalCursorSize = _currentCursorSize = 0;
				return;
			}
			_currentCursorSize = currentSize - decrease;
			// 下限
			if (_currentCursorSize < _originalCursorSize)
				_currentCursorSize = _originalCursorSize;
			// 上限
			if (MaxDecaMouse < _currentCursorSize)
				_currentCursorSize = MaxDecaMouse;
			// 既に戻しきってるなら変える必要はない？
			if (currentSize == _currentCursorSize)
			{
				_originalCursorSize = _currentCursorSize = 0;
				return;
			}
			_ = SystemParametersInfo(SPI_SETMOUSECURSORSIZE, 0, new IntPtr(_currentCursorSize), SPIF_SENDCHANGE);
		}

		/// <summary>
		/// マウスポインターサイズの復帰
		/// </summary>
		private void RestoreMouse()
		{
			if (_originalCursorSize == 0)
				return;
			if (!_chkGraduallyShirink.Checked)
			{
				// 一気に戻す
				if (!SystemParametersInfo(SPI_GETMOUSECURSORSIZE, 0, _valueBuffer, 0))
					return;
				var currentSize = Marshal.ReadInt32(_valueBuffer);
				// 自分が設定したサイズでない場合は戻さない
				if (currentSize == _originalCursorSize || currentSize != _currentCursorSize)
					return;
				// 初期サイズに戻す
				_ = SystemParametersInfo(SPI_SETMOUSECURSORSIZE, 0, new IntPtr(_originalCursorSize), SPIF_SENDCHANGE);
				// 初期状態に戻す
				_originalCursorSize = _currentCursorSize = 0;
			}
			else
			{
				// じわじわ戻す
				RestoreMouse(_tbGraduallyShirink.Value);
			}
		}

		/// <summary>
		/// スタートアップに登録する
		/// </summary>
		/// <param name="applicationPath">実行ファイルのフルパス</param>
		/// <returns>成功したらtrue</returns>
		public static bool RegisterStartup(string applicationPath)
		{
			try
			{
				using (var key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true))
					key?.SetValue(ApplicationName, $"\"{applicationPath}\"");
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// スタートアップから登録解除する
		/// </summary>
		/// <returns>成功したらtrue</returns>
		public static bool UnregisterStartup()
		{
			try
			{
				using (var key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true))
					key?.DeleteValue(ApplicationName, false);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// スタートアップに登録されているか確認する
		/// </summary>
		/// <returns>登録されていればtrue</returns>
		public static bool IsRegisteredStartup()
		{
			try
			{
				using (var key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, false))
					return key?.GetValue(ApplicationName) != null;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 自動起動チェックのクリックイベントハンドラー。チェックの状態に応じてスタートアップへの登録/解除を行い、チェックの状態を更新します。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _chkAutoExec_Click(object sender, EventArgs e)
		{
			if (!_chkAutoExec.Checked)
				_ = RegisterStartup(Application.ExecutablePath);
			else
				_ = UnregisterStartup();
			_chkAutoExec.Checked = IsRegisteredStartup();
		}

		/// <summary>
		/// タイマーのTickイベントハンドラー。マウスポインターの位置をサンプリングし、設定された条件に基づいてアクションを実行します。
		/// また、ふりふりカウントと振られてないカウントを更新し、フォーム上のラベルに表示します。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _timSample_Tick(object sender, EventArgs e)
		{
			bool executeAction(ApplicationSettings.Actions action)
			{
				switch (action)
				{
					case ApplicationSettings.Actions.IncreasePointerSize:
						BigMouse(_chkGraduallyEnlarge.Checked ? _tbGraduallyEnlarge.Value : MaxDecaMouse);
						return false;
					case ApplicationSettings.Actions.MoveToCenter:
						Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
						return true;
					default:
						return false;
				}
			}
			bool resetAction(ApplicationSettings.Actions action)
			{
				switch (action)
				{
					case ApplicationSettings.Actions.IncreasePointerSize:
						RestoreMouse();
						return false;
					default:
						return false;
				}
			}
			// 横の処理
			if (_shakeDetectorX.AddSample(Cursor.Position.X))
			{
				if (executeAction(_settings.ActionX))
					_shakeDetectorX.Reset();
				_shakeX++;
				_noShakeX = 0;
			}
			else
			{
				if (_noShakeX < _shakeDetectorX.Cooldown)
				{
					_noShakeX++;
				}
				else
				{
					if (resetAction(_settings.ActionX))
						_shakeDetectorX.Reset();
					_shakeX = 0;
				}
			}
			_lblValueX.Text = _shakeX.ToString();
			// 縦の処理
			if (_shakeDetectorY.AddSample(Cursor.Position.Y))
			{
				if (executeAction(_settings.ActionY))
					_shakeDetectorY.Reset();
				_shakeY++;
				_noShakeY = 0;
			}
			else
			{
				if (_noShakeY < _shakeDetectorY.Cooldown)
				{
					_noShakeY++;
				}
				else
				{
					if (resetAction(_settings.ActionY))
						_shakeDetectorY.Reset();
					_shakeY = 0;
				}
			}
			_lblValueY.Text = _shakeY.ToString();
		}

		/// <summary>
		/// UIを表示する
		/// </summary>
		private void ShowUI()
		{
			Visible = true;
			TopMost = true;
			TopMost = false;
		}

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tbCooldown_Scroll(object sender, EventArgs e) =>
			_shakeDetectorX.Cooldown = _tbCooldownX.Value + _tbDirectionChangeX.Value;

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tbDistance_Scroll(object sender, EventArgs e) =>
			_shakeDetectorX.Deadzone = _tbDistanceX.Value;

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tbDirectionChange_Scroll(object sender, EventArgs e)
		{
			_shakeDetectorX.Cooldown = _tbCooldownX.Value + _tbDirectionChangeX.Value;
			_shakeDetectorX.DirectionChanges = _tbDirectionChangeX.Value;
		}

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tbCooldownY_Scroll(object sender, EventArgs e) =>
			_shakeDetectorY.Cooldown = _tbCooldownY.Value + _tbDirectionChangeY.Value;

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tbDistanceY_Scroll(object sender, EventArgs e) =>
			_shakeDetectorY.Deadzone = _tbDistanceY.Value;

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tbDirectionChangeY_Scroll(object sender, EventArgs e)
		{
			_shakeDetectorY.Cooldown = _tbCooldownY.Value + _tbDirectionChangeY.Value;
			_shakeDetectorY.DirectionChanges = _tbDirectionChangeY.Value;
		}

		/// <summary>
		/// トレイアイコンのダブルクリックイベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _niTray_DoubleClick(object sender, EventArgs e) => ShowUI();

		/// <summary>
		/// 設定メニューのクリックイベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tsmiSettings_Click(object sender, EventArgs e) => ShowUI();

		/// <summary>
		/// 終了メニューのクリックイベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _tsmiExit_Click(object sender, EventArgs e)
		{
			_closing = true;
			this.Close();
		}

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _radBigMouseX_CheckedChanged(object sender, EventArgs e) => GetActionsFromFormX();

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _radCenterMouseX_CheckedChanged(object sender, EventArgs e) => GetActionsFromFormX();

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _radNoneX_CheckedChanged(object sender, EventArgs e) => GetActionsFromFormX();

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _radCenterMouseY_CheckedChanged(object sender, EventArgs e) => GetActionsFromFormY();

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _radBigMouseY_CheckedChanged(object sender, EventArgs e) => GetActionsFromFormY();

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _radNoneY_CheckedChanged(object sender, EventArgs e) => GetActionsFromFormY();

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _chkGraduallyEnlarge_CheckedChanged(object sender, EventArgs e) => _pnlGraduallyEnlarge.Enabled = _chkGraduallyEnlarge.Checked;

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _chkGraduallyShirink_CheckedChanged(object sender, EventArgs e) => _pnlGraduallyShirink.Enabled = _chkGraduallyShirink.Checked;

		/// <summary>
		/// UIからの設定変更イベントハンドラー。
		/// </summary>
		/// <param name="sender">イベントの送信元</param>
		/// <param name="e">イベントデータ</param>
		private void _chkIgnoreButtonHeld_CheckedChanged(object sender, EventArgs e) =>
			_shakeDetectorX.IgnoreMouseButtonHeld = _settings.IgnoreMouseButtonHeld = _chkIgnoreButtonHeld.Checked;
	}
}
