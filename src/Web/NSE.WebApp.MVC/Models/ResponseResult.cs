﻿namespace NSE.WebApp.MVC.Models
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }
        public string Title { get; set; }
        public int Status { get; set; }

        public ResponseErrorMessages Errors { get; set; }
    }
}
