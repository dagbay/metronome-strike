using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine; // need to access LoadPlayer script
using System; //not directly used - needed for an exception


namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            player.health.Increment();


            try{
                PlayerData data = SaveSystem.LoadPlayer();
                Vector3 position;
                position.x = data.position[0];
                position.y = data.position[1];
                position.z = data.position[2];

                player.Teleport(position);
            }
            catch (NullReferenceException)
            {
                player.Teleport(model.spawnPoint.transform.position);
            }
            
            player.jumpState = PlayerController.JumpState.Grounded;
            player.animator.SetBool("dead", false);
            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;
            Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}