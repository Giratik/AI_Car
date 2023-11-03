using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.SceneManagement;

public class agentScript : Agent
{
    public CarControler car;  // R�f�rence au script de contr�le de la voiture
    private Rigidbody theRB;  // R�f�rence au composant Rigidbody de l'agent

    public override void Initialize()
    {
        // Initialisation de la r�f�rence au Rigidbody de l'agent
        theRB = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // R�initialisation de la sc�ne et de la position de la voiture
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        car.ResetCar();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Actions discr�tes de l'agent pour contr�ler la voiture
        float forwardMovement = 0f;
        float steeringAngle = 0f;

        // Actions discr�tes pour l'avant/arri�re
        switch (actions.DiscreteActions[0])
        {
            case 0: forwardMovement = 0f; break;   // Aucun mouvement
            case 1: forwardMovement = 1f; break;   // Avancer
            case 2: forwardMovement = -1f; break;  // Reculer
        }

        // Actions discr�tes pour la direction
        switch (actions.DiscreteActions[1])
        {
            case 0: steeringAngle = 0f; break;    // Aucune direction
            case 1: steeringAngle = 1f; break;    // Tourner � droite
            case 2: steeringAngle = -1f; break;   // Tourner � gauche
        }

        // Appliquer les actions � la voiture
        car.SetSpeedInput(forwardMovement);
        car.SetTurnInput(steeringAngle);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Mode "Heuristic" pour le contr�le manuel de la voiture (pour les tests)
        int forwardMovementAction = 0;
        int steeringMovementAction = 0;

        if (Input.GetKey(KeyCode.W)) forwardMovementAction = 1;
        else if (Input.GetKey(KeyCode.S)) forwardMovementAction = 2;

        if (Input.GetKey(KeyCode.D)) steeringMovementAction = 1;
        else if (Input.GetKey(KeyCode.A)) steeringMovementAction = 2;

        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = forwardMovementAction;
        discreteActions[1] = steeringMovementAction;
    }
}
