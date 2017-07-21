﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Skarp.HubSpotClient.Interfaces;

namespace Skarp.HubSpotClient.Requests
{
    internal class RequestDataConverter
    {
        public RequestDataConverter()
        {
            
        }

        /// <summary>
        /// Converts the given <paramref name="entity"/> to a hubspot data entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public HubspotDataEntity ToHubspotDataEntity(IHubSpotEntity entity)
        {
            var mapped = new HubspotDataEntity();
            var allProps = entity.GetType().GetProperties();

            foreach (var prop in allProps)
            {
                if (prop.Name.Equals("RoutePath")) continue;

                var propValue = prop.GetValue(entity);
                var item = new HubspotDataEntityProp
                {
                    Property = prop.Name,
                    Value = propValue?.ToString()
                };

                mapped.Properties.Add(item);
            }

            return mapped;
        } 
    }
}