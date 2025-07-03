import React, { useEffect, useState } from 'react'
import Fooddata from './FoodData'
import "./style.css"
import Form from 'react-bootstrap/Form'
import Cards from './Cards'
import axios from 'axios';



const Search = () => {

  const [copydata, setCopyData] = useState([]);
  const apiBase = "http://localhost:44366/";


  useEffect(() => {
    
    axios.get(`${apiBase}/api/zmt`)
    .then(response => {
      console.log(response);
      
      setCopyData(response.data);
    })
    .catch(error => console.log(error));

  }, [])



  // console.log(copydata);


  const chanegData = (searchText) => {
    let getchangedata = searchText.toLowerCase();

    if (getchangedata == "") {
      setCopyData(Fooddata);
    } else {
      let storedata = Fooddata.filter((ele, k) => {
        return ele.rname.toLowerCase().match(getchangedata);
      });

      setCopyData(storedata)
    }

  }


  const zomatologo = "https://b.zmtcdn.com/web_assets/b40b97e677bc7b2ca77c58c61db266fe1603954218.png"



  return (
    <>



      <Form className='d-flex justify-content-center align-items-center mt-3'>
        <Form.Group className=" mx-2 col-lg-4" controlId="formBasicEmail">

          <Form.Control type="text"
            onChange={(e) => chanegData(e.target.value)}
            placeholder="Search  Resturant" />

        </Form.Group>
        {/* <button className='btn text-light col-lg-1'  style={{ background: '#ed4c67' }}>Refresh </button> */}
      </Form>

      <section className='iteam_section mt-4 container'>
        <h2 className='px-4' style={{ fontWeight: 400 }}>Restaurants in Udupi Open now </h2>

        <div className="row mt-2 d-flex justify-content-around align-items-center ">
          {(copydata && copydata.length > 0) ? <Cards data={copydata} /> : "No Items Found"}
        </div>
      </section>

    </>
  )
}

export default Search
