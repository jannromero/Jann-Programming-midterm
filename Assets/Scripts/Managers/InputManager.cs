using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{

    private static GameControls _gameControls;

   public static void Init(Player myPlayer){
      _gameControls = new GameControls();

      _gameControls.Permanent.Enable(); 

      _gameControls.InGame.Movement.performed += jeff => { //look for input
          myPlayer.SetMovementDirection(jeff.ReadValue<Vector>()); //action performed
       };
   }

   public static void SetGameControls(){
     _gameControls.InGame.Enable();
     _gameControls.UI.Disable();
   }

   public static void SetUIControls(){
     _gameControls.InGame.Disable();
     _gameControls.UI.Enable();
   }
}