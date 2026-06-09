using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DecaMouse
{
	/// <summary>
	/// 設定
	/// </summary>
	public class ApplicationSettings
	{
		/// <summary>
		/// 動作
		/// </summary>
		public enum Actions
		{
			/// <summary>
			/// なんもしない
			/// </summary>
			None,
			/// <summary>
			/// ポインターを大きくする
			/// </summary>
			IncreasePointerSize,
			/// <summary>
			/// プライマリモニターの中心に移動する
			/// </summary>
			MoveToCenter
		}

		public static ApplicationSettings Default => new ApplicationSettings();

		/// <summary>
		/// 動作X
		/// </summary>
		public Actions ActionX { get; set; } = Actions.IncreasePointerSize;

		/// <summary>
		/// 動作Y
		/// </summary>
		public Actions ActionY { get; set; } = Actions.MoveToCenter;

		/// <summary>
		/// 復帰までのサンプリング回数X
		/// </summary>
		public int CooldownX { get; set; } = 50;

		/// <summary>
		/// 復帰までのサンプリング回数Y
		/// </summary>
		public int CooldownY { get; set; } = 50;

		/// <summary>
		/// 1サンプリングあたりの最低移動量X
		/// </summary>
		public int DeadzoneX { get; set; } = 50;

		/// <summary>
		/// 1サンプリングあたりの最低移動量Y
		/// </summary>
		public int DeadzoneY { get; set; } = 50;

		/// <summary>
		/// 反転回数X
		/// </summary>
		public int DirectionChangesX { get; set; } = 5;

		/// <summary>
		/// 反転回数Y
		/// </summary>
		public int DirectionChangesY { get; set; } = 5;

		/// <summary>
		/// マウスボタンが押されているときは無視する
		/// </summary>
		public bool IgnoreMouseButtonHeld { get; set; } = true;

		/// <summary>
		/// ポインター拡大時にじわじわ大きくなる
		/// </summary>
		public bool GraduallyIncreasePointerSize { get; set; } = false;

		/// <summary>
		/// ポインターサイズ増加量
		/// </summary>
		public int IncreasePointerSize { get; set; } = 16;

		/// <summary>
		/// ポインター縮小時にじわじわ小さくなる
		/// </summary>
		public bool GraduallyDecreasePointerSize { get; set; } = false;

		/// <summary>
		/// ポインターサイズ減少量
		/// </summary>
		public int DecreasePointerSize { get; set; } = 16;

		/// <summary>
		/// 読み込み
		/// </summary>
		/// <param name="path">パス</param>
		/// <returns>設定</returns>
		/// <remarks>何かトラブったら既定値を返す</remarks>
		public static ApplicationSettings Load(string path)
		{
			var serializer = new XmlSerializer(typeof(ApplicationSettings));
			try
			{
				using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				using (var reader = new StreamReader(stream))
					return (ApplicationSettings)serializer.Deserialize(reader);
			}
			catch
			{
				// ファイルの読み込みに失敗した場合はデフォルト値を返す
				return ApplicationSettings.Default;
			}
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <param name="path">パス</param>
		/// <remarks>何かトラブったら黙って諦める</remarks>
		public void Save(string path)
		{
			var serializer = new XmlSerializer(typeof(ApplicationSettings));
			try
			{
				_ = Directory.CreateDirectory(Path.GetDirectoryName(path));
				using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
				using (var writer = new StreamWriter(stream, Encoding.UTF8))
					serializer.Serialize(writer, this);
			}
			catch { /* ignored */ }
		}
	}
}
