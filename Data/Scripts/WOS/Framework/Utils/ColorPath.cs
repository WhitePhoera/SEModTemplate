#line 2
using System;
using System.Collections;
#line 2
using System.Collections.Generic;
using VRageMath;

namespace Phoera.Framework.Utils
{
    public class ColorPath:IEnumerable
    {
        class ColorPathPart
        {
            public Color Color { get; set; }
            public Color ColorEnd { get; set; }
            public ulong Length { get; set; }
            public double Part { get; set; }
        }

        List<ColorPathPart> Parts = new List<ColorPathPart>();
        ColorPathPart curPart;
        int current = 0;
        ulong currentT = 0;
        bool colorCalculated = false;
        Color cache;
        Color last;
        bool _loop;

        public ColorPath(Color start, bool loop = false)
        {
            _loop = loop;
            cache = last = start;
            colorCalculated = true;

        }
        public ulong Length { get; private set; } 
        public void Add(Color color, ulong timeout)
        {
            Parts.Add(new ColorPathPart { Color = last, ColorEnd = color, Length = timeout, Part = 1.0 / timeout });
            if (Parts.Count == 1)
                curPart = Parts[0];
            last = color;
            Length += timeout;
            colorCalculated = false;
        }
        public Color Color
        {
            get
            {
                if (colorCalculated)
                    return cache;
                return curPart.Color.LerpTo(curPart.ColorEnd, curPart.Part * currentT);
            }
        }

        public void Update()
        {
            if (Parts.Count == 0)
                return;
            if (Parts.Count == 1)
            {
                currentT++;
                if (currentT > curPart.Length)
                    currentT = 0;
                colorCalculated = false;
                return;
            }
            ulong nextC = currentT + 1;
            if (current == Parts.Count - 1 && nextC > curPart.Length && !_loop)
                return;
            currentT = nextC;
            colorCalculated = false;
            if (currentT > curPart.Length)
            {
                currentT = 0;
                if (current == Parts.Count - 1 && _loop)
                {
                    current = 0;
                }
                else if (current < Parts.Count - 1)
                {
                    current++;
                }
                curPart = Parts[current];
            }

        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Parts).GetEnumerator();
        }
    }
}

