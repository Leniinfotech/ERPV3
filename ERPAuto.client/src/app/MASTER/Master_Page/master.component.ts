import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-master',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css'],
})
export class MasterComponent {
  sidebarExpanded = false;
  activeMenu: string | null = null;
  isAnimating = false; // new flag to prevent jitter
  constructor(private router: Router) { }

  toggleMenu(menu: string): void {
    if (this.isAnimating) return; // prevent multiple fast clicks

    this.isAnimating = true;

    if (this.activeMenu === menu && this.sidebarExpanded) {
      // closing the same menu
      this.sidebarExpanded = false;

      setTimeout(() => {
        this.activeMenu = null;
        this.isAnimating = false;
      }, 310); // matches CSS transition
    } else {
      // switching or opening new
      this.activeMenu = menu;
      this.sidebarExpanded = true;

      setTimeout(() => {
        this.isAnimating = false;
      }, 310); // allow animation to complete
    }
  }
  onLogout(): void {
    if (confirm('Are you sure you want to logout?')) {
      localStorage.clear();
      sessionStorage.clear();
      this.router.navigate(['/login']);
    }
  }
}
