using System.Collections.Generic;
using com.ksgames.core.abstractions.persistence.enums;
using com.ksgames.services.persistenceservice;
using R3;

namespace OnBoardingCore.Game.ExampleTopGame
{
    public class ExampleGameDataProvider: RootPersistenceProvider<ExampleGameData>
    {
        public ExampleGameDataProvider(string gameStateKey)
        {
            GAME_STATE_KEY = gameStateKey;
            State = new ReactiveProperty<PersistenceProviderStateEnum>(PersistenceProviderStateEnum.INPROGRESS);
        }


        public override ExampleGameData CreateDataFromSettings()
        {
            var entities = new List<int>() { 1,2,3,4,5};
            Data = new ExampleGameData(entities);
            return Data;
        }
    }
}