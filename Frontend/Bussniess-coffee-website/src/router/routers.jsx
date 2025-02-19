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
    path: "/admin-dashboard",
    element: (
      <ProtectedRoute allowedRoles={"admin"}>
        <ScrollToTop />
        <Outlet />
      </ProtectedRoute>
    ),
    children: [
      {
        path: "dashboard",
        element: <AdminDashboard />,
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
