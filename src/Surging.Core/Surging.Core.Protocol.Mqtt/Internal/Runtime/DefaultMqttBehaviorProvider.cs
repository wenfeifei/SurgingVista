﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Runtime.Server;
using Surging.Core.Protocol.Mqtt.Internal.Services;
using System.Linq;

namespace Surging.Core.Protocol.Mqtt.Internal.Runtime
{
    public class DefaultMqttBehaviorProvider : IMqttBehaviorProvider
    {
        #region Field

        private readonly IServiceEntryProvider _serviceEntryProvider;
        private readonly CPlatformContainer _serviceProvider;
        private MqttBehavior _mqttBehavior;

        #endregion Field

        #region Constructor

        public DefaultMqttBehaviorProvider(IServiceEntryProvider serviceEntryProvider,  CPlatformContainer serviceProvider)
        {
            _serviceEntryProvider = serviceEntryProvider;
            _serviceProvider = serviceProvider;
        }

        #endregion Constructor

        public MqttBehavior GetMqttBehavior()
        {
            if (_mqttBehavior == null)
            {
                _mqttBehavior = _serviceEntryProvider.GetTypes()
                    .Select(type=> _serviceProvider.GetInstances(type) as MqttBehavior).SingleOrDefault(); 
              
            }
            return _mqttBehavior;
        }
    }
}
