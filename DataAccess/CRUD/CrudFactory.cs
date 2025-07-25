﻿using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    //Clase padre/madre abstracta de los crud
    //define como se hacen cruds en la arquitectura
    public abstract class CrudFactory
    {
        protected SqlDao _sqlDao;

        //Definir los métodos que forman parte del contrato
        //C = Create
        //R = Retrieve
        //U = Update
        //D = Delete

        public abstract void Create(BaseDTO baseDTO);
        public abstract void Update(BaseDTO baseDTO);
        public abstract void Delete(BaseDTO baseDTO);

        public abstract T Retrieve<T>();
        public abstract T RetrieveById<T>();
        public abstract List<T> RetrieveAll<T>();
    }
}
