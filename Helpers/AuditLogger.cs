﻿using GetECINo.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetECINo.Helpers  
{
    public class AuditLogger
    {
        public static void RequestInfo(string transactionID,string method,string path,string queryString,string payload)
        {
            AuditMiddleware.Logger.Information(
                string.Format("Request:TransactionID-{0},Method-{1},Path-{2},QueryString-{3},Payload-{4}",
                transactionID, method, path, queryString, payload
               ));
        }
        public static void ResponseInfo(string transactionID, string method, string path, string queryString,string databasename,string collectionName, string payload)
        {
            AuditMiddleware.Logger.Information(
                string.Format("Request:TransactionID-{0},Method-{1},Path-{2},QueryString-{3},DatabaseName-{4},CollectionName-{5},Payload-{6}",
                transactionID, method, path, queryString,databasename,collectionName, payload
               ));
        }


    }   
}
