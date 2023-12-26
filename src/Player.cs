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

    public float getLeft() {
        return _position.X;
    }

    public float getRight() {
        return _position.X + _width;
    }
}