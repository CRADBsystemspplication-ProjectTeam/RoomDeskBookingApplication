namespace ConferenceRoomAndDeskBookingApplication.Models
{
    public enum UserRole
    {
        User,
        Admin
    }

    public enum EmailStatus
    {
        Pending,
        Sent,
        Failed
    }

    public enum NotificationType
    {
        BookingConfirmation,
        BookingCancellation,
        EntryReminder,
        CheckInReminder,
        ExitReminder,
        OverdueReminder,
        NoShowWarning,
        MaintenanceAlert
    }

    public enum BroadcastNotificationType
    {
        EventAnnouncement,
        MaintenanceAlert,
        SystemUpdate,
        PolicyUpdate
    }

    public enum BookingStatus
    {
        Confirmed,
        CheckedIn,
        Completed,
        Cancelled,
        NoShow
    }

    public enum NotificationStatus
    {
        Pending,
        Sent,
        Failed,
        Read
    }

    public enum ResourceType
    {
        Room,
        Desk
    }
}
