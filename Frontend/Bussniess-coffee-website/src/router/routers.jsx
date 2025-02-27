import Footer from "@/components/Footer/Footer";
import Header from "@/components/Header/Header";
import ScrollToTop from "@/components/ScrollTop/ScrollToTop";
import ForgotPasswordPage from "@/pages/ForgotPasswordPage/ForgotPasswordPage";
import HomePage from "@/pages/HomePage/HomePage";
import NotFoundPage from "@/pages/NotFoundPage/NotFoundPage";
import SignInPage from "@/pages/SignInPage/SignInPage";
import SignUpPage from "@/pages/SignUpPage/SignUpPage";
import { createBrowserRouter, Outlet } from "react-router-dom";
import ProtectedRoute from "./ProtectedRoute";
import NotAuthorized from "@/pages/NotAuthorized/NotAuthorized";
import AdminDashboard from "@/pages/admin/dashboard/AdminDashboard";
import CustomerDashboard from "@/pages/customer/dashboard/CustomerDashboard";
import ProductPage from "@/pages/ProductPage/ProductPage";
import ProductDetailPage from "@/pages/ProductDetailPage/ProductDetailPage";
import AdminLayout from "@/pages/admin/layout/AdminLayout";

export const router = createBrowserRouter([
  {
    path: "/",
    element: (
      <>
        <Header />
        <ScrollToTop />
        <Outlet />
        <Footer />
      </>
    ),
    children: [
      {
        path: "/",
        element: <HomePage />,
      },
      {
        path: "sign-in",
        element: <SignInPage />,
      },
      {
        path: "sign-up",
        element: <SignUpPage />,
      },
      {
        path: "forgot-password",
        element: <ForgotPasswordPage />,
      },
      {
        path: "products",
        element: <ProductPage />,
      },
      {
        path: "products/:productID",
        element: <ProductDetailPage />,
      },
    ],
  },
  {
    path: "/admin",
    element: (
      <ProtectedRoute allowedRoles={"admin"}>
        <ScrollToTop />
        <AdminLayout/>
      </ProtectedRoute>
    ),
    children: [
      {
        path: "dashboard",
        element: <AdminDashboard />,
      },
      {
        path:'setting',
        element:<div><h1>Setting Page</h1></div>
      },
      {
        path:'promotion',
        element:<div><h1>Promotion Page</h1></div>
      },
      {
        path:'product/coffee-bean',
        element:<div><h1>Coffee Bean Page</h1></div>
      },
      {
        path:'product/coffee-mix',
        element:<div><h1>Coffee Mix Page</h1></div>
      },
      {
        path:'product/category',
        element:<div><h1>Category Page</h1></div>
      },
      {
        path:'orders',
        element:<div><h1>Order Page</h1></div>
      },
      {
        path:'customers',
        element:<div><h1>Customer Page</h1></div>
      },
      {
        path:'account',
        element:<div><h1>Account Page</h1></div>
      },
    ],
  },
  {
    path: "/customer-dashboard",
    element: (
      <ProtectedRoute allowedRoles={"customer"}>
        <ScrollToTop />
        <Outlet />
      </ProtectedRoute>
    ),
    children: [
      {
        path: "dashboard",
        element: <CustomerDashboard />,
      },
    ],
  },
  {
    path: "/page-not-found",
    element: <NotFoundPage />,
  },
  {
    path: "/not-authorized",
    element: <NotAuthorized />,
  },
]);
