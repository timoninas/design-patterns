using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    // Special label for builder
    public class Label
    {
        private uint _frameX = 0;
        private uint _frameY = 0;
        private string _font = "";
        private uint _countOfLines = 0;

        public void setFrame(uint x, uint y)
        {
            this._frameX = x;
            this._frameY = y;
        }
        public void setFont(string nameFont)
        {
            this._font = nameFont;
        }
        public void setCountLines(uint count)
        {
            this._countOfLines = count;
        }

        public void showReportAboLabel()
        {
            Console.WriteLine("Label with frame: " + this._frameX.ToString() + "x" + this._frameY.ToString());
            Console.WriteLine("Label font name: " + _font);
            Console.WriteLine("Label count of line: " + this._countOfLines.ToString());
        }
    }

    // Director manage with Builder
    public class Director
    {
        private BuilderLabel _builder;

        public BuilderLabel Builder
        {
            set { _builder = value; }
        }

        public void BuildLittleLabel()
        {
            this._builder.BuildFrameLabel();
            this._builder.BuildFont();
            this._builder.BuildCountOfLine();
        }
    }
    
    public interface BuilderLabel
    {
        public void BuildFrameLabel();
        public void BuildFont();
        public void BuildCountOfLine();
    }
    
    public class LittleLabelBuilder : BuilderLabel
    {
        private Label _label;

        public LittleLabelBuilder()
        {
            reset();
        }

        public void BuildFrameLabel()
        {
            this._label.setFrame(200, 50);
        }

        public void BuildFont()
        {
            this._label.setFont("Helvetica, 12 pt.");
        }
        
        public void BuildCountOfLine()
        {
            this._label.setCountLines(1);
        }
        
        private void reset()
        {
            _label = new Label();
        }
        
        public Label getLittleLabel()
        {
            Label resultLabel = this._label;
            resultLabel.showReportAboLabel();

            this.reset();

            return resultLabel;
        }
    }
}
