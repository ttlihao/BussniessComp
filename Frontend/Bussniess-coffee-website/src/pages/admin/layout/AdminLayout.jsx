import React, { useState } from "react";
import { Link, Outlet, useLocation, useNavigate } from "react-router-dom";
import "./AdminLayout.scss";
import { BsBoxSeam, BsDot } from "react-icons/bs";
import { RiDiscountPercentLine } from "react-icons/ri";
import { IoBarChartOutline, IoSettingsOutline } from "react-icons/io5";
import {
  FaAngleDown,
  FaAngleUp,
  FaRegBell,
  FaRegUserCircle,
} from "react-icons/fa";
import { CiShoppingBasket } from "react-icons/ci";
import { GrDocumentUser, GrLogout } from "react-icons/gr";
import { Breadcrumb } from "antd";

function AdminLayout() {
  const { pathname } = useLocation();
  const [openDropdown, setOpenDropdown] = useState(null);
  const navigate = useNavigate();

  const DataList = [
    {
      path: "/admin/product",
      label: "Products",
      icon: <BsBoxSeam size={18} />,
      children: [
        {
          path: "/admin/product/coffee-bean",
          label: "Coffee Bean",
          icon: <BsDot size={18} />,
        },
        {
          path: "/admin/product/coffee-mix",
          label: "Coffee Mix",
          icon: <BsDot size={18} />,
        },
        {
          path: "/admin/product/category",
          label: "Category",
          icon: <BsDot size={18} />,
        },
      ],
    },
    {
      path: "/admin/promotion",
      label: "Promotion",
      icon: <RiDiscountPercentLine size={18} />,
    },
    {
      path: "/admin/account",
      label: "Account",
      icon: <FaRegUserCircle size={18} />,
    },
    {
      path: "/admin/setting",
      label: "Setting",
      icon: <IoSettingsOutline size={18} />,
    },
  ];

  const MenuList = [
    {
      path: "/admin/dashboard",
      label: "Dashboard",
      icon: <IoBarChartOutline size={18} />,
    },
    {
      path: "/admin/orders",
      label: "Orders",
      icon: <CiShoppingBasket size={18} />,
    },
    {
      path: "/admin/customers",
      label: "Customers",
      icon: <GrDocumentUser size={18} />,
    },
  ];

  const itemLast = [
    {
      path: "#",
      label: "Logout",
      icon: <GrLogout size={18} />,
    },
  ];

  const findMenuItem = (path) => {
    const parentItem =
      DataList.find((item) => path.startsWith(item.path)) ||
      MenuList.find((item) => path.startsWith(item.path));

    if (!parentItem) return null; // Nếu không có mục cha, trả về null

    // Nếu `path` trùng với `path` của mục cha, trả về label của nó
    if (parentItem.path === path) return parentItem.label;

    // Tìm trong danh sách `children` của mục cha
    const childItem = parentItem.children?.find((child) => child.path === path);

    return childItem ? childItem.label : parentItem.label;
  };

  const pathParts = pathname
    .split("/")
    .filter((part) => part && part !== "admin");

  // Hàm chuyển đổi đường dẫn
  const formatLabel = (str) => {
    return str
      .replace(/-/g, " ") // Thay '-' thành ' '
      .replace(/\b\w/g, (char) => char.toUpperCase()); // Viết hoa chữ đầu
  };

  // Tạo danh sách breadcrumb items
  const breadcrumbItems = [
    { path: "/", label: "Home" }, // Home luôn là mục đầu tiên
    ...pathParts.map((part, index) => {
      const path = `/${pathParts.slice(0, index + 1).join("/")}`;
      return { path, label: formatLabel(part) };
    }),
  ];

  const handleNavigate = (path, index) => {
    navigate(path);
    setOpenDropdown(openDropdown === index ? null : index); // Toggle dropdown
  };

  const handleToggleDropdown = (e, index) => {
    e.stopPropagation(); // Ngăn chặn event lan lên trên (tránh navigate)
    setOpenDropdown(openDropdown === index ? null : index);
  };

  // console.log(currentMenuItem);

  return (
    <div className="al-conmtainer">
      <div className="admin-sidebar">
        <h1 className="as-brand">
          GuYou <span>Coffee</span>
        </h1>
        <div className="as-account-view">
          <img
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzXYJjodFz_K34O-knK2K_A80iwv4007bb3Q&s"
            alt="avatar"
          />
          <h2 className="account-name">Stella Menalie</h2>
          <h3 className="account-role">Administrator</h3>
        </div>
        <div className="as-choose">
          <h4 className="title">Master Data</h4>
          <ul className="menu">
            {DataList.map((item, index) => (
              <li key={index} className="menu-item">
                <div
                  className={`menu-link ${
                    pathname === item.path ? "active" : ""
                  }`}
                  onClick={(e) => {
                    if (item.children) {
                      handleToggleDropdown(e, index); // Chỉ mở dropdown, không navigate
                    } else {
                      handleNavigate(item.path, index); // Navigate nếu không có children
                    }
                  }}
                >
                  <span className="menu-icon">{item.icon}</span>
                  <span className="menu-label">{item.label}</span>
                  {item.children && (
                    <span className="menu-dropdown-icon">
                      {openDropdown === index ? <FaAngleUp /> : <FaAngleDown />}
                    </span>
                  )}
                </div>

                {item.children && openDropdown === index && (
                  <ul className="submenu">
                    {item.children.map((subItem, subIndex) => (
                      <li
                        key={subIndex}
                        className={`submenu-item ${
                          pathname === subItem.path ? "active" : ""
                        }`}
                        onClick={() => navigate(subItem.path)}
                      >
                        <span className="submenu-icon">{subItem.icon}</span>
                        <span className="submenu-label">{subItem.label}</span>
                      </li>
                    ))}
                  </ul>
                )}
              </li>
            ))}
          </ul>

          {/* </div> */}
        </div>
        <div className="as-choose">
          <h4 className="title">Master Data</h4>
          <ul className="menu">
            {MenuList.map((item, index) => (
              <li key={index} className="menu-item">
                <div
                  className={`menu-link ${
                    pathname === item.path ? "active" : ""
                  }`}
                  onClick={() => navigate(item.path)}
                >
                  <span className="menu-icon">{item.icon}</span>
                  <span className="menu-label">{item.label}</span>
                </div>
              </li>
            ))}
          </ul>
        </div>
        <div className="as-choose">
          <ul className="menu">
            {itemLast.map((item, index) => (
              <li key={index} className="menu-item">
                <div
                  className="menu-link"
                  onClick={() => handleNavigate(item.path, index)}
                >
                  <span className="menu-icon">{item.icon}</span>
                  <span className="menu-label">{item.label}</span>
                </div>
              </li>
            ))}
          </ul>
        </div>
      </div>
      <div className="admin-div">
        <div className="admin-header">
          <div className="link">
            {/* <h1>{currentMenuItem?.label || "Page Not Found"}</h1> */}
            <h1>{findMenuItem(pathname) || "Page Not Found"}</h1>
            {/* <Breadcrumb style={{ marginBottom: 16 }}>
              {breadcrumbItems.map((item, index) => (
                <Breadcrumb.Item key={index}>
                  {index === breadcrumbItems.length - 1 ? (
                    item.label // Hiển thị text nếu là mục cuối
                  ) : (
                    <Link to={item.path}>
                      {item.label}
                    </Link> // Link điều hướng
                  )}
                </Breadcrumb.Item>
              ))}
            </Breadcrumb> */}
            <Breadcrumb style={{ marginBottom: 16, fontSize: 16 }}>
              {breadcrumbItems.map((item, index) => (
                <Breadcrumb.Item key={index}>
                  {index === breadcrumbItems.length - 1 ? (
                    <span style={{ fontSize: 17 }}>{item.label}</span> // Áp dụng font-size cho mục cuối
                  ) : (
                    <Link to={item.path} style={{ fontSize: 17 }}>
                      {item.label}
                    </Link>
                  )}
                </Breadcrumb.Item>
              ))}
            </Breadcrumb>
          </div>
          <div className="notice-btn">
            <FaRegBell size={22} />
          </div>
        </div>
        <Outlet />
      </div>
    </div>
  );
}

export default AdminLayout;
