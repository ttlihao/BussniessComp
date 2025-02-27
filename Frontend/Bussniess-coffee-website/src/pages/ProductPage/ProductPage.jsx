import React from "react";
import "./ProductPage.scss";
import { useNavigate } from "react-router-dom";
import { CoffeeCard } from "@/components/CoffeeCard/CoffeeCard";

function ProductPage() {
  const filterList = [
    {
      key: 1,
      label: "TRUYỀN THỐNG",
    },
    {
      key: 2,
      label: "NHẸ NHÀNG & THANH LỊCH",
    },
    {
      key: 3,
      label: "CÂN BẰNG & HÀI HÒA",
    },
    {
      key: 4,
      label: "ĐẬM ĐÀ & MẠNH MẼ",
    },
    {
      key: 5,
      label: "NHỌT NGÀO & BÉO MỊN",
    },
    {
      key: 6,
      label: "THƯ GIÃN & NGỌT NGÀO",
    },
    {
      key: 7,
      label: "KÍCH THÍCH NĂNG LƯỢNG",
    },
  ];
  const navigate = useNavigate();
  return (
    <div className="mt-[82px] pp-container">
      <div className="pp-div">
        <div className="pp-wrapper filter-wrapper">
          <h3>TẤT CẢ</h3>
          {filterList.map((item) => (
            <p className="filter-item" key={item.key}>
              {item.label}
            </p>
          ))}
        </div>
        <div className="pp-wrapper">
          {Array.from({ length: 9 }, (_, index) => (
            <CoffeeCard />
          ))}
        </div>
      </div>
    </div>
  );
}



export default ProductPage;
