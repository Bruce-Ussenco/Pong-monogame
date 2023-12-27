using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
//using System.Net.NetworkInformation;

namespace Pong_monogame;

public class Ball {
    Vector2 _position;
    Vector2 _velocity;

    float _speed;

    int _screenWidth;
    int _screenHeight;

    int _diameter;
    int _radius;

    Texture2D _texture;

    public Ball(int screenWidth, int screenHeight, float speed, Texture2D texture) {
        _position = new Vector2(screenWidth/2, screenHeight/2);
        _speed = speed;
        SetVelocity(_speed);

        _texture = texture;

        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        _diameter = _texture.Width;
        _radius = _diameter/2;
    }

    void SetVelocity(float speed) {
        Random rnd = new Random();
        double angle = rnd.NextDouble() *120 -60; // angle between -60 and 60 deg
        angle *= Math.PI /180.0;                  // convert to radians

        float x = (float)Math.Cos(angle);
        x *= rnd.NextDouble() < 0.5 ? -1f : 1f; // 50% chance to mirror
        float y = (float)Math.Sin(angle);

        _velocity = new Vector2(x, y); // set the direction
        _velocity *= speed;            // set the speed
    }

    public void Update(ref Player player0, ref Player player1) {
        _position += _velocity;

        if ( // player0 horizontal collision
            (_position.X - _radius < player0.getRight() && _velocity.X < 0) &&
            (_position.Y < player0.getDown()) &&
            (_position.Y > player0.getUp())
        ) _velocity.X *= -1;

        if ( // player1 horizontal collision
            (_position.X + _radius > player1.getLeft() && _velocity.X > 0) &&
            (_position.Y < player1.getDown()) &&
            (_position.Y > player1.getUp())
        ) _velocity.X *= -1;

        if (  // vertical collision
            (_position.Y + _radius > _screenHeight && _velocity.Y > 0) ||
            (_position.Y < _radius && _velocity.Y < 0)
        ) _velocity.Y *= -1;
    }

    public int GoalCollision() {
        int player;

        if (_position.X + _radius > _screenWidth)
            player = 0;
        else if (_position.X < _radius)
            player = 1;
        else
            player = -1;

        return player;
    }

    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw( // draw texture
            _texture,
            new Rectangle(
                (int)_position.X - _radius,
                (int)_position.Y - _radius,
                _diameter, _diameter
            ),
            Color.White
        );
    }

    public void Reset() {
        _position = new Vector2(_screenWidth/2, _screenHeight/2);
        SetVelocity(_speed);
    }
}