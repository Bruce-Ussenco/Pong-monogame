using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong_monogame;

public class Player {
    Texture2D _texture;

    public Vector2 _position;
    float _speed;

    int _playerNum;

    public int _width;
    public int _height;

    int _screenWidth;
    int _screenHeight;

    public Player(int screenWidth, int screenHeight, int playerNum, float speed, Texture2D texture) {
        _screenWidth  = screenWidth;
        _screenHeight = screenHeight;

        _speed = speed;

        _texture = texture;
        _width   = texture.Width;
        _height  = texture.Height;

        _playerNum = playerNum;

        _position = new Vector2(0, 0);

        _position.X = (playerNum == 0) ? 0 :  _screenWidth - _width;
        
        _position.Y = _screenHeight /2;
    }

    public void Update() {
        if (_playerNum == 0) {
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
                _position.Y = Math.Max(_height/2, _position.Y - _speed);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
                _position.Y = Math.Min(_screenHeight - _height/2, _position.Y + _speed);
            }
        }
        else {

        }
    }

    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw( // draw texture
            _texture,
            new Rectangle(
                (int)_position.X,
                (int)_position.Y - _height /2,
                _width, _height
            ),
            Color.White
        );
    }

    public float getLeft() => _position.X;           // x pos of left face
    public float getRight() => _position.X + _width; // right face ...
    public float getDown() => _position.Y + _height /2;
    public float getUp() => _position.Y - _height /2;
}