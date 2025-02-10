import Footer from "@/components/Footer/Footer";
import Header from "@/components/Header/Header";
import ScrollToTop from "@/components/ScrollTop/ScrollToTop";
import ForgotPasswordPage from "@/pages/ForgotPasswordPage/ForgotPasswordPage";
import HomePage from "@/pages/HomePage/HomePage";
import NotFoundPage from "@/pages/NotFoundPage/NotFoundPage";
import SignInPage from "@/pages/SignInPage/SignInPage";
import SignUpPage from "@/pages/SignUpPage/SignUpPage";
import { createBrowserRouter, Outlet } from "react-router-dom";

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
        path: "/sign-in",
        element: <SignInPage />,
      },
      {
        path: "/sign-up",
        element: <SignUpPage />,
      },
      {
        path: "/forgot-password",
        element: <ForgotPasswordPage />,
      },
    ],
  },
  {
    path: "/page-not-found",
    element: <NotFoundPage />,
  },
]);
