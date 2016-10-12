﻿using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class RiasMethods : ApiMethodContainer
    {
        public RiasMethods(AuthToken token) : base("Portfolio", "Rias", token) { }

        public List<RIA> Get()
        {
            return GetAsync().Result;
        }
        public async Task<List<RIA>> GetAsync()
        {
            JToken rias = await GetJsonAsync("");
            return rias.ToObject<List<RIA>>();
        }

        public RIA Get(int riaId)
        {
            return GetAsync(riaId).Result;
        }
        public async Task<RIA> GetAsync(int riaId)
        {
            JToken ria = await GetJsonAsync(riaId.ToString());
            return ria.ToObject<RIA>();
        }

        public List<RIASimple> GetSimple()
        {
            return GetSimpleAsync().Result;
        }
        public async Task<List<RIASimple>> GetSimpleAsync()
        {
            JToken rias = await GetJsonAsync("Simple");
            return rias.ToObject<List<RIASimple>>();
        }
    }
}