using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            LittleLabelBuilder builder = new LittleLabelBuilder();
            director.Builder = builder;

            Label label;

            director.BuildLittleLabel();

            label = builder.getLittleLabel();

            /* OUTPUT
             * Label with frame: 200x50
             * Label font name: Helvetica, 12 pt.
             * Label count of line: 1
             */
        }
    }
}
