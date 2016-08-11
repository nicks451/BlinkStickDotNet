﻿using System;
using System.Drawing;

namespace BlinkStickDotNet.Animations.Implementations
{
    /// <summary>
    /// Pulse animation.
    /// </summary>
    /// <seealso cref="BlinkStickDotNet.Animations.AnimationBase" />
    public class PulseAnimation : AnimationBase
    {
        private int _duration;
        private Color[] _colors;

        /// <summary>
        /// Initializes a new instance of the <see cref="PulseAnimation" /> class.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <param name="colors">The colors.</param>
        public PulseAnimation(int duration, params Color[] colors)
        {
            if (colors.Length < 0)
            {
                throw new ArgumentNullException(nameof(colors));
            }

            _duration = duration;
            _colors = colors;
        }

        /// <summary>
        /// Starts the animation.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public override void Start(IBlinkStickColorProcessor processor)
        {
            var duration = _duration / 2;

            //set to black
            processor.ProcessColors(Color.Black);

            //morph to color
            MorphAnimation.Morph(processor, duration, _colors);

            //morph to black
            MorphAnimation.Morph(processor, duration, Color.Black);
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// The clone.
        /// </returns>
        public override IAnimation Clone()
        {
            return new PulseAnimation(_duration, _colors);
        }
    }
}