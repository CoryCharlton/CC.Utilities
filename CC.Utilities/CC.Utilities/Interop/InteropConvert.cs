using System;
using System.Drawing;
using System.Windows.Forms;

namespace CC.Utilities.Interop
{
    public static class InteropConvert
    {
        // ReSharper disable InconsistentNaming
        public static FontStyle CFE_ToFontStyle(CFE dwEffects)
        {
            return CFM_ToFontStyle((CFM)dwEffects);
        }
        
        public static FontStyle CFM_ToFontStyle(CFM dwMask)
        {
            FontStyle fontStyle = 0;

            if ((dwMask & CFM.BOLD) == CFM.BOLD)
            {
                fontStyle |= FontStyle.Bold;
            }

            if ((dwMask & CFM.ITALIC) == CFM.ITALIC)
            {
                fontStyle |= FontStyle.Italic;
            }

            if ((dwMask & CFM.STRIKEOUT) == CFM.STRIKEOUT)
            {
                fontStyle |= FontStyle.Strikeout;
            }

            if ((dwMask & CFM.UNDERLINE) == CFM.UNDERLINE)
            {
                fontStyle |= FontStyle.Underline;
            }

            return fontStyle;
        }

        public static CFM FontStyleTo_CFE(FontStyle fontStyle)
        {
            return FontStyleTo_CFM(fontStyle);
        }
        
        public static CFM FontStyleTo_CFM(FontStyle fontStyle)
        {
            CFM cfm_ = 0;

            if ((fontStyle & FontStyle.Bold) == FontStyle.Bold)
            {
                cfm_ |= CFM.BOLD;
            }

            if ((fontStyle & FontStyle.Italic) == FontStyle.Italic)
            {
                cfm_ |= CFM.ITALIC;
            }

            if ((fontStyle & FontStyle.Strikeout) == FontStyle.Strikeout)
            {
                cfm_ |= CFM.STRIKEOUT;
            }

            if ((fontStyle & FontStyle.Underline) == FontStyle.Underline)
            {
                cfm_ |= CFM.UNDERLINE;
            }

            return cfm_;
        }

        public static PFA HorizontalAlignmentTo_PFA(HorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case HorizontalAlignment.Center:
                    {
                        return PFA.CENTER;
                    }
                case HorizontalAlignment.Left:
                    {
                        return PFA.LEFT;
                    }
                case HorizontalAlignment.Right:
                    {
                        return PFA.RIGHT;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("alignment", alignment, "Invalid 'alignment' value.");
                    }
            }
        }

        public static HorizontalAlignment PFA_ToHorizontalAlignment(PFA pfa)
        {
            switch (pfa)
            {
                case PFA.CENTER:
                    {
                        return HorizontalAlignment.Center;
                    }
                case PFA.LEFT:
                    {
                        return HorizontalAlignment.Left;
                    }
                case PFA.RIGHT:
                    {
                        return HorizontalAlignment.Right;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("pfa", pfa, "Invalid PFA value.");
                    }
            }
        }
        // ReSharper restore InconsistentNaming
    }
}
