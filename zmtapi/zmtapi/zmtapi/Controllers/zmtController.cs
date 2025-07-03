using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using zmtapi.Models;

namespace zmtapi.Controllers
{
    public class zmtController : ApiController
    {

        // api/zmt
        public IHttpActionResult GetFoodData()
        {
            try
            {



                using (zmtdbEntities db = new zmtdbEntities())
                {
                    List<zmtmodel> res = db.foodData.Select(obj => new zmtmodel
                    {
                        id = obj.id,
                        arrimg = obj.arrimg,
                        delimg = obj.delimg,
                        imgdata = obj.imgdata,
                        price = obj.price,
                        rating = obj.rating,
                        address = obj.address,
                        rname = obj.rname,
                        somedata = obj.somedata,

                    }).ToList();
                    return Ok(res);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IHttpActionResult GetFoodData(int key)
        {
            try
            {
                using (zmtdbEntities db = new zmtdbEntities())
                {
                    var reslst = db.foodData.Where(poo => poo.id == key).ToList();
                    if (!reslst.Any())
                    {
                        return BadRequest("FOOD DATA OT FOUND");
                    }
                    zmtmodel res = reslst.Select(obj => new zmtmodel
                    {
                        id = obj.id,
                        arrimg = obj.arrimg,
                        delimg = obj.delimg,
                        imgdata = obj.imgdata,
                        price = obj.price,
                        rating = obj.rating,
                        address = obj.address,
                        rname = obj.rname,
                        somedata = obj.somedata,

                    }).First();
                    return Ok(res);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IHttpActionResult PostFoodData(zmtmodel obj)
        {

            try
            {

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                using (zmtdbEntities db = new zmtdbEntities())
                {
                    foodData food = new foodData();

                    food.id = obj.id;
                    food.arrimg = obj.arrimg;
                    food.delimg = obj.delimg;
                    food.imgdata = obj.imgdata;
                    food.price = obj.price;
                    food.rating = obj.rating;
                    food.address = obj.address;
                    food.rname = obj.rname;
                    food.somedata = obj.somedata;

                    db.foodData.Add(food);
                    db.SaveChanges();

                    return Ok(food.id);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IHttpActionResult PutFoodData(int key, zmtmodel obj)
        {
            try
            {
                using (zmtdbEntities db = new zmtdbEntities())
                {
                    if (!ModelState.IsValid)
                        return BadRequest("Invalid data.");

                    var reslst = db.foodData.Where(poo => poo.id == key).ToList();
                    if (!reslst.Any())
                    {
                        return BadRequest("FOOD DATA OT FOUND");
                    }
                    foodData food = reslst.First();

                    //food.id = obj.id;
                    food.arrimg = obj.arrimg;
                    food.delimg = obj.delimg;
                    food.imgdata = obj.imgdata;
                    food.price = obj.price;
                    food.rating = obj.rating;
                    food.address = obj.address;
                    food.rname = obj.rname;
                    food.somedata = obj.somedata;

                    db.Entry(food).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(food.id);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IHttpActionResult DeleteFoodData(int key)
        {
            try
            {
                using (zmtdbEntities db = new zmtdbEntities())
                {


                    var reslst = db.foodData.Where(poo => poo.id == key).ToList();
                    if (!reslst.Any())
                    {
                        return BadRequest("FOOD DATA OT FOUND");
                    }
                    foodData food = reslst.First();

                    db.foodData.Remove(food);

                    db.SaveChanges();

                    return Ok(food.id);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Diagnoal()
        {
            try
            {
                int[,] arr = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 9, 8, 9 } };

                int diagnol1 = 0;
                int diagnol2 = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == j)
                        {
                            diagnol1 = diagnol1 + arr[i, j];
                        }

                        if (j == (2 - i))
                        {
                            diagnol2 = diagnol2 + arr[i, j];
                        }

                    }

                }
                int diff = (diagnol1 - diagnol1);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    /*
    public void Ratio()
    {
        try
        {
            int[] arr = [1, 1, 0, -1, -1];
            double zero = arr.Count(val => val == 0);
            double positive = arr.Count(val => val > 0);
            double negative = arr.Count(val => val < 0);

            Console.WriteLine(string.Format("zero: {0}", (zero / arr.Count()).ToString("F6")));
            Console.WriteLine(string.Format("positive: {0}", (positive / arr.Count()).ToString("F6")));
            Console.WriteLine(string.Format("negative: {0}", (negative / arr.Count()).ToString("F6")));
        }
        catch (Exception)
        {

            throw;
        }
    }
*/
}



