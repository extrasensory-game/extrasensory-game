namespace ExtrasensoryGame.Enums
{
    public enum CharacterCharacteristic
    {
        Purchase = 0,
        ALoss,
        Love,
        Parting,
        Optimism,
        Pessimism,
        Calmness,
        Aggression
    }

    public static class CharacterCharacteristicExtention
    {
        public static string GetString(this CharacterCharacteristic characteristic)
        {
            switch (characteristic)
            {
                case CharacterCharacteristic.Purchase:
                    return "приобретение";
                case CharacterCharacteristic.ALoss:
                    return "потеря";
                case CharacterCharacteristic.Love:
                    return "любовь";
                case CharacterCharacteristic.Parting:
                    return "расставание";
                case CharacterCharacteristic.Optimism:
                    return "оптимизм";
                case CharacterCharacteristic.Pessimism:
                    return "оптимизм";
                case CharacterCharacteristic.Calmness:
                    return "спокойствие";
                case CharacterCharacteristic.Aggression:
                    return "агрессия";
            }

            return string.Empty;
        }
    }
}