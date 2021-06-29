using System;
namespace TemplateMethod
{
    public abstract class FormLoadTemplateMethod
    {
        public string NameForm { get; private set; }
        public string Frame { get; private set; }
        public string Log { get; protected set; }

        public FormLoadTemplateMethod(string nameForm, string frame)
        {
            NameForm = nameForm;
            Frame = frame;
            Log = "";
        }

        public void LoadScreen()
        {
            Log = $"{NameForm} -> {Frame}\n";
            LoadForm();
            FormDidLoad();
            FormWillAppear();
            FormDidAppear();
        }

        protected abstract void LoadForm();
        protected abstract void FormDidLoad();
        protected abstract void FormWillAppear();
        protected abstract void FormDidAppear();
    }

    public class FullScreenForm: FormLoadTemplateMethod
    {
        public FullScreenForm(string nameForm, string frame) : base(nameForm, frame) { }

        protected override void LoadForm()
        {
            Log += $"{NameForm} :- LoadForm\n";
        }

        protected override void FormDidLoad()
        {
            Log += $"{NameForm} :- FormDidLoad\n";
        }

        protected override void FormWillAppear()
        {
            Log += $"{NameForm} :- FormWillAppear\n";
        }

        protected override void FormDidAppear()
        {
            Log += $"{NameForm} :- FormDidAppear\n\n";
        }
    }
}
