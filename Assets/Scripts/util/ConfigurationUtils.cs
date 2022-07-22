using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides utility access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	#region Fields

	static ConfigurationData configurationData;

	#endregion


	#region Properties
	
	public static float Player_JumpForce
    {
        get { return configurationData.playerJumpForce; }
    }
	
	public static float RotationSpeed
    {
        get { return configurationData.RotationSpeed; }
    }

    #endregion


	#region Public methods

	/// <summary>
	/// Initializes the configuration data by creating the ConfigurationData object 
	/// </summary>
	public static void Initialize()
	{
        configurationData = new ConfigurationData();
	}

	#endregion
}
