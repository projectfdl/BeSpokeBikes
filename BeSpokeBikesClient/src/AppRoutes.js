import { CustomerList } from "./components/CustomerList";
import { SalespersonList } from "./components/SalespersonList";
import { DiscountList } from "./components/DiscountList";
import { ProductList } from "./components/ProductList";
import { SaleList } from "./components/SaleList";

const AppRoutes = [
    {
        index: true,
        element: <SaleList />
    },
    {
        path: '/customer-list',
        element: <CustomerList />
    },
    {
        path: '/salesperson-list',
        element: <SalespersonList />
    },
    {
        path: '/discount-list',
        element: <DiscountList />
    },
    {
        path: '/product-list',
        element: <ProductList />
    },
    {
        path: '/sale-list',
        element: <SaleList />
    },
];

export default AppRoutes;
