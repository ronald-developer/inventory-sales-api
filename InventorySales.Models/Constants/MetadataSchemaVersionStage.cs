namespace InventorySales.Models.Constants
{
    /// <summary>
    /// Represents the stages of a metadata schema version lifecycle.
    /// </summary>
    /// <remarks>This class provides constants that define the possible stages of a metadata schema version.
    /// Use these values to indicate or check the current stage of a metadata schema version.</remarks>
    public static class  MetadataSchemaVersionStage
    {
        /// <summary>
        /// Represents the status of an item that is in a draft state.
        /// </summary>
        /// <remarks>This constant can be used to indicate that an item is not finalized and is still
        /// being edited or reviewed.</remarks>
        public const string Draft = "Draft";

        /// <summary>
        /// Represents the status indicating that an item or action has been approved.
        /// </summary>
        public const string Approved = "Approved";
    }
}
