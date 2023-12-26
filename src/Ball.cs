using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Net.NetworkInformation;

namespace Pong_monogame;

public class Ball {
    Vector2 _position;
    Vector2 _velocity;

    int _screenWidth;
    int _screenHeight;

    int _width;
    int _height;
    int _radius;

    Texture2D _texture;

    public Ball(int screenWidth, int screenHeight, float speed, Texture2D texture) {
        _position = new Vector2(screenWidth/2, screenHeight/2);
        _texture = texture;

        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        _width = _texture.Width;
        _height = _texture.Height;

        _radius = _width/2;

        Random rnd = new Random();
        double angle = rnd.NextDouble() * 140 - 70; // angle between -70 and 70 deg
        angle *= Math.PI /180.0;                   // convert to radians
        angle = + 0.1;

        float x = (float)Math.Cos(angle);
        x *= rnd.NextDouble() < 0.5 ? -1f : 1f; // 50% chance to mirror
        float y = (float)Math.Sin(angle);

        _velocity = new Vector2(x, y); // set the direction
        _velocity *= speed;            // set the speed
    }

    public void Update() {
        _position += _velocity;

        if (
            (_position.X + _radius > _screenWidth && _velocity.X > 0) ||
            (_position.X - _radius < 0 && _velocity.X < 0)
        ) _velocity.X *= -1;

        if (
            (_position.Y + _radius > _screenHeight && _velocity.Y > 0) ||
            (_position.Y - _radius < 0 && _velocity.Y < 0)
        ) _velocity.Y *= -1;
    }

    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(
            _texture,
            new Rectangle(
                (int)_position.X - _width/2,
                (int)_position.Y - _height/2,
                _width, _height
            ),
            Color.White
        );
    }
}