"use client";

import Link from 'next/link';
import { usePathname } from 'next/navigation';

const Sidebar = () => {
  const pathname = usePathname();

  const navItems = [
    { name: 'Dashboard', path: '/' },
    { name: 'Manage', path: '/manage' },
  ];

  return (
    <div className="h-screen w-64 bg-gradient-to-b from-gray-900 via-gray-800 to-gray-700 text-white shadow-lg flex flex-col">
      <div className="p-6 text-3xl font-extrabold tracking-wide border-b border-gray-600">
        SITS
      </div>
      <nav className="flex-1 mt-6">
        <ul className="space-y-3">
          {navItems.map((item) => (
            <li key={item.path}>
              <Link href={item.path}>
                <span
                  className={`block py-3 px-6 rounded-lg text-lg font-medium transition-all duration-200 ${
                    pathname === item.path
                      ? 'bg-blue-500 shadow-lg shadow-blue-500/50 text-white'
                      : 'text-gray-300 hover:bg-blue-400 hover:text-white hover:shadow-md hover:shadow-blue-400/40'
                  }`}
                >
                  {item.name}
                </span>
              </Link>
            </li>
          ))}
        </ul>
      </nav>
      <div className="p-6 border-t border-gray-600">
        <p className="text-gray-400 text-sm text-center">
          © {new Date().getFullYear()} SITS. All rights reserved.
        </p>
      </div>
    </div>
  );
};

export default Sidebar;