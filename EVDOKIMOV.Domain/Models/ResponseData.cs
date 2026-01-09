using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDOKIMOV.Domain.Models
{
    public class ResponseData<T>
    {
        public ResponseData()
        { }
        // запрашиваемые данные
        public T? Data { get; set; }
        // признак успешного завершения запроса
        public bool Success { get; set; } = true;
        // сообщение в случае неуспешного завершения
        public string? ErrorMessage { get; set; } = string.Empty;
        /// <summary>
        /// успешный ответ
        /// </summary>
        /// <param name="data">передаваемые данные</param>
        /// <returns></returns>
        public static ResponseData<T> OK(T? data)
        {
            return new ResponseData<T> { Data = data };
        }
        /// <summary>
        /// ошибка
        /// </summary>
        /// <param name="message">текст сообщения об ошибке</param>
        /// <returns></returns>
        public static ResponseData<T> Error(string message)
        {
            return new ResponseData<T>
            {
                ErrorMessage = message,
                Success = false,
                Data = (T)Activator.CreateInstance(typeof(T))
            };
        }
    }
}
