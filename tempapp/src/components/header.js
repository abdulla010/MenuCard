import React from 'react'
import Button from 'react-bootstrap/Button';
import { useNavigate } from "react-router-dom"

const Header = () => {
  const zomatologo = "https://b.zmtcdn.com/web_assets/b40b97e677bc7b2ca77c58c61db266fe1603954218.png"
 
    const navigate = useNavigate();
    const onClickOrderNow = (pathu) => {
    navigate(pathu);
     }
  return (
    <>
      <div className="container d-flex justify-content-between align-items-center">
        <img src={zomatologo} style={{ width: "8rem", position: "relative", left: "2%", cursor: "pointer" }} alt="" />
        <h2 style={{ color: "#1b1464", cursor: "pointer" }} className="mt-3">
          Search Filter App
        </h2>
        <div className='btn-group'>
          <Button variant="outline-primary" onClick={() =>onClickOrderNow('/')}>   Home  </Button>
        <Button variant="outline-primary" onClick={() =>onClickOrderNow('/Contact')}>   Add Item  </Button>
        </div>
      </div>
    </>
  )
}

export default Header
