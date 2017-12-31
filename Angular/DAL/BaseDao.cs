using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace DAL
{
    public class BaseDao<T> where T : class, new()
    {
        DbContext content = GetCurrentDbContext();//获取EF上下文

        //保证一次请求共用一个上下文实例
        public static DbContext GetCurrentDbContext()
        {
            #region CallContext

            //一个线程共用一个上下文实例。一次请求就用一个线程。

            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;

            if (dbContext == null)
            {
                dbContext = new ModelContainer();
                CallContext.SetData("DbContext", dbContext);
            }

            return dbContext;

            #endregion
        }

        /// <summary>
        /// 加载实体集合
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList()
        {
            return content.Set<T>().AsQueryable<T>();
        }

        /// <summary>
        /// 加载实体集合
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(Func<T, bool> whereLambda)
        {
            return content.Set<T>().Where<T>(whereLambda).AsQueryable<T>();
        }

        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(Func<T, bool> whereLambda, int pageIndex, int pageSize, out int totalCount)
        {
            var tmp = content.Set<T>().Where<T>(whereLambda);
            totalCount = tmp.Count();

            return tmp.Skip<T>(pageSize * (pageIndex - 1))//跳过行数，最终生成的sql语句是Top(n)
                      .Take<T>(pageSize) //返回指定数量的行
                      .AsQueryable<T>();
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>返回更新后的实体</returns>
        public virtual T Add(T entity)
        {
            content.Set<T>().Add(entity);
            content.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>返回更新后的实体</returns>
        public virtual T Edit(T entity)
        {
            content.Set<T>().Attach(entity);
            content.Entry<T>(entity).State = EntityState.Modified;//将附加的对象状态更改为修改
            content.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            content.Set<T>().Attach(entity);
            content.Entry<T>(entity).State = EntityState.Deleted;//将附加的实体状态更改为删除
            if (content.SaveChanges() > 0)
            {
                return true;//删除成功
            }
            else
            {
                return false;//删除失败
            }
        }

        /// <summary>
        /// 根据条件删除对象
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public virtual bool Delete(Func<T, bool> whereLambda)
        {
            var tmp = content.Set<T>().Where<T>(whereLambda);//根据条件从数据库中获取对象集合
            foreach (var entity in tmp)
            {
                content.Entry<T>(entity).State = EntityState.Deleted;//标记对象为删除状态删除
            }
            if (content.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}