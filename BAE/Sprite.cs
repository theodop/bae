using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace BAE
{
    public class Sprite
    {
        private Texture2D _texture;
        private Rectangle _sourceRectangle;
        private int _noOfFrames, _frameTime;
        private int _timeSinceLastFrame = 0;
        private int _currentFrame = 0;
        private Vector2 _origin;

        public Sprite(Texture2D texture, Rectangle sourceRectangle, Vector2 origin, int noOfFrames = 1, int frameTime = 0)
        {
            _texture = texture;
            _sourceRectangle = sourceRectangle;
            _sourceRectangle.Location = new Point(0, 0);
            _origin = origin;
            _noOfFrames = noOfFrames;
            _frameTime = frameTime;
        }

        public void Update(GameTime gameTime)
        {
            if (_frameTime > 0)
            {
                _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

                if (_timeSinceLastFrame > _frameTime)
                {
                    _currentFrame += Math.Floor(_timeSinceLastFrame / _frameTime);
                    _currentFrame %= _noOfFrames;
                    _timeSinceLastFrame %= _frameTime;

                    _sourceRectangle.X = _sourceRectangle.Width * _currentFrame;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale = 1.0f)
        {
            spriteBatch.Draw(_texture, position, _sourceRectangle, Color.White, 0.0f, _origin, scale, SpriteEffects.None, 0.0f);
        }
    }
}
