using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfBehaviorPractice
{
    /// <summary>
    /// ボタンを押したら、警告ダイアログボックスが出るという振る舞い
    /// </summary>
    public class AlertBehavior : Behavior<Button>
    {
        public AlertBehavior()
        {
        }

        /// <summary>
        /// ダイアログボックスに表示する任意の文字列です
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(AlertBehavior), new UIPropertyMetadata(null));

        /// <summary>
        /// 要素にアタッチされたときの処理。大体イベントハンドラの登録処理をここでやる
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Click += Alert;
        }

        /// <summary>
        /// 要素にデタッチされたときの処理。大体イベントハンドラの登録解除をここでやる
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Click -= Alert;
        }

        /// <summary>
        /// メッセージが入力されていたらメッセージボックスを出す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Alert(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Message))
            {
                return;
            }

            MessageBox.Show(this.Message);
        }
    }
}
