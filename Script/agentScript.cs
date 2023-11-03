using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.SceneManagement;

public class agentScript : Agent
{
    public CarControler car;  // Référence au script de contrôle de la voiture
    private Rigidbody theRB;  // Référence au composant Rigidbody de l'agent

    public override void Initialize()
    {
        // Initialisation de la référence au Rigidbody de l'agent
        theRB = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // Réinitialisation de la scène et de la position de la voiture
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        car.ResetCar();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Actions discrètes de l'agent pour contrôler la voiture
        float forwardMovement = 0f;
        float steeringAngle = 0f;

        // Actions discrètes pour l'avant/arrière
        switch (actions.DiscreteActions[0])
        {
            case 0: forwardMovement = 0f; break;   // Aucun mouvement
            case 1: forwardMovement = 1f; break;   // Avancer
            case 2: forwardMovement = -1f; break;  // Reculer
        }

        // Actions discrètes pour la direction
        switch (actions.DiscreteActions[1])
        {
            case 0: steeringAngle = 0f; break;    // Aucune direction
            case 1: steeringAngle = 1f; break;    // Tourner à droite
            case 2: steeringAngle = -1f; break;   // Tourner à gauche
        }

        // Appliquer les actions à la voiture
        car.SetSpeedInput(forwardMovement);
        car.SetTurnInput(steeringAngle);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Mode "Heuristic" pour le contrôle manuel de la voiture (pour les tests)
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
