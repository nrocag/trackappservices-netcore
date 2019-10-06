namespace Entities.Response
{
    public class Message
    {
        /// <summary>
        /// Guardado exitosamente
        /// </summary>
        public static Message Message1
        {
            get
            {
                return new Message(1, "Guardado exitosamente");
            }
        }

        /// <summary>
        /// Consultado exitosamente
        /// </summary>
        public static Message Message2
        {
            get
            {
                return new Message(2, "Consultado exitosamente");
            }
        }

        /// <summary>
        /// No existen registros
        /// </summary>
        public static Message Message3
        {
            get
            {
                return new Message(3, "No existen registros");
            }
        }

        /// <summary>
        /// Eliminado exitosamente
        /// </summary>
        public static Message Message4
        {
            get
            {
                return new Message(4, "Eliminado exitosamente");
            }
        }

        private Message(int code, string text) {
            this.Code = code;
            this.Text = text;
        }

        public int Code { get; set; }

        public string Text { get; set; }
    }
}