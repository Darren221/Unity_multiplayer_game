using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
namespace gameserver
{
    class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        private Vector3 inputs;

        public Player(int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = Quaternion.Identity;

            inputs = new Vector3();
        }

        public void Update()
        {
            Vector2 _inputDirection = Vector2.Zero;
            Move(_inputDirection);
        }

        private void Move(Vector2 _inputDirection)
        {
            this.position = inputs;
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

        public void SetInput(Vector3 _inputs, Quaternion _rotation)
        {
            inputs = _inputs;
            rotation = _rotation;
        }
    }
}
