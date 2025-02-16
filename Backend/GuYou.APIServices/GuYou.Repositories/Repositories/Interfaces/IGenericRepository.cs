﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    Task<List<T>> GetAllAsync();
    void Create(T entity);
    Task<T> CreateAsync(T entity);
    void Update(T entity);
    Task<bool> UpdateAsync(T entity);
    bool Remove(T entity);
    Task<bool> RemoveAsync(T entity);
    T GetById(int id);
    Task<T> GetByIdAsync(int id);
    T GetById(string code);
    Task<T> GetByIdAsync(string code);
    T GetById(Guid code);
    Task<T> GetByIdAsync(Guid code);
    void PrepareCreate(T entity);
    void PrepareUpdate(T entity);
    void PrepareRemove(T entity);
    int Save();
    Task<int> SaveAsync();
}
