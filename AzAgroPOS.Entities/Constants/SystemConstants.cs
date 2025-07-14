namespace AzAgroPOS.Entities.Constants
{
    public static class SystemConstants
    {
        public static class Status
        {
            public const string Active = "Aktiv";
            public const string Inactive = "Deaktiv";
            public const string Deleted = "Silindi";
        }

        public static class RepairStatus
        {
            public const string Received = "Received";
            public const string InProgress = "InProgress";
            public const string Ready = "Ready";
            public const string Delivered = "Delivered";
            public const string Cancelled = "Cancelled";
        }

        public static class RepairStatusAzerbaijani
        {
            public const string Received = "Qəbul Edildi";
            public const string InProgress = "İşlənir";
            public const string Ready = "Hazır";
            public const string Delivered = "Təhvil Verildi";
            public const string Cancelled = "İptal";
        }

        public static class Priority
        {
            public const string Low = "Low";
            public const string Medium = "Medium";
            public const string High = "High";
            public const string Urgent = "Urgent";
        }

        public static class PriorityAzerbaijani
        {
            public const string Low = "Aşağı";
            public const string Medium = "Orta";
            public const string High = "Yüksək";
            public const string Urgent = "Təcili";
        }

        public static class DebtStatus
        {
            public const string Open = "Açıq";
            public const string PartiallyPaid = "Qismən Ödənilmiş";
            public const string FullyPaid = "Tam Ödənilmiş";
            public const string Overdue = "Gecikmiş";
        }

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Manager = "Manager";
            public const string Worker = "Worker";
            public const string Cashier = "Cashier";
        }

        public static class StepStatus
        {
            public const string Waiting = "Gözləyir";
            public const string InProgress = "İşlənir";
            public const string Completed = "Bitdi";
            public const string Cancelled = "İptal";
        }
    }
}