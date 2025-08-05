namespace SimpleBookStore.Utility
{
    public static class Constant
    {
        public static class JWTDescription
        {
            public static readonly string Key = "ThisIsA32CharacterMinimumSecretKey!";
            public static readonly string Issuer = "https://localhost:7191/";
            public static readonly string Audience = "https://localhost:7191/";
        }

        public static class Role
        {
            public static readonly string Person = "Person";
            public static readonly string SuperAdmin = "SuperAdmin";
        }
    }
}
